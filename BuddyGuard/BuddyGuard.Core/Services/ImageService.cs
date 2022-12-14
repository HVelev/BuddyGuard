using BuddyGuard.Core.Contracts;
using Amazon.S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3.Model;
using BuddyGuard.Core.Models;
using System.Net;
using System.Threading.Tasks.Dataflow;

namespace BuddyGuard.Core.Services
{
    public class ImageService : IImageService
    {
        public async Task<HttpStatusCode> AddImage(EditImageDTO image)
        {
            var fileName = image.Image.FileName;

            var extension = Path.GetExtension(fileName);

            if (extension == null 
                || extension == string.Empty 
                || extension != ".png" 
                || extension != ".gif" 
                || extension != ".svg"
                || extension != ".jpg"
                || extension != ".jpeg"
                || extension != ".jfif"
                || extension != ".pjp"
                || extension != ".avif"
                || extension != ".apng"
                || extension != ".webp"
                || extension != ".pjpeg")
            {
                throw new ArgumentException();
            }

            var awsKey = "AKIAW4ROKHDZ7KHWLHUK";
            var awsSecretKey = "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";
            var bucketRegion = Amazon.RegionEndpoint.USEast1;
            var s3 = new AmazonS3Client(awsKey, awsSecretKey, bucketRegion);
            var putRequest = new PutObjectRequest();
            putRequest.BucketName = "buddyguard";
            putRequest.ContentType = "image/jpeg";
            putRequest.InputStream = image.Image.OpenReadStream();
            putRequest.Key = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            PutObjectResponse putResponse = await s3.PutObjectAsync(putRequest);
            return putResponse.HttpStatusCode;
        }

        public async Task<List<ImageDTO>> GetImages()
        {
            var awsKey = "AKIAW4ROKHDZ7KHWLHUK";
            var awsSecretKey = "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";
            var bucketRegion = Amazon.RegionEndpoint.USEast1;
            var s3 = new AmazonS3Client(awsKey, awsSecretKey, bucketRegion);

            try
            {
                var images = new List<ImageDTO>();

                var objects = await s3.ListObjectsAsync("buddyguard");

                foreach (var obj in objects.S3Objects.OrderByDescending(x => x.LastModified))
                {
                    var expires = DateTime.Now.AddHours(1);

                    GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
                    {
                        BucketName = "buddyguard",
                        Key = obj.Key,
                        Expires = expires,
                    };

                    var url = s3.GetPreSignedURL(request);

                    images.Add(new ImageDTO
                    {
                        Name = request.Key,
                        ImageUrl = url,
                    });
                }

                return images;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteImage(string key)
        {
            var awsKey = "AKIAW4ROKHDZ7KHWLHUK";
            var awsSecretKey = "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";
            var bucketRegion = Amazon.RegionEndpoint.USEast1;
            var s3 = new AmazonS3Client(awsKey, awsSecretKey, bucketRegion);


            var obj = await s3.GetObjectAsync("buddyguard", key);


            var request = new DeleteObjectRequest
            {
                BucketName= "buddyguard",
                Key = key,
                VersionId = obj.VersionId,
            };

            await s3.DeleteObjectAsync(request);
        }
    }
}
