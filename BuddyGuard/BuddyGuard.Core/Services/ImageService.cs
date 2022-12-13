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

namespace BuddyGuard.Core.Services
{
    public class ImageService : IImageService
    {
        public async Task<HttpStatusCode> AddImage(EditImageDTO image)
        {
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

        public async Task<DeleteObjectsResponse> DeleteImage(string key)
        {
            var awsKey = "AKIAW4ROKHDZ7KHWLHUK";
            var awsSecretKey = "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";
            var bucketRegion = Amazon.RegionEndpoint.USEast1;
            var s3 = new AmazonS3Client(awsKey, awsSecretKey, bucketRegion);

            var request = new DeleteObjectsRequest
            {
                BucketName = "buddyguard",
                Objects = new List<KeyVersion>()
            };

            request.Objects.Add(new KeyVersion
            {
                Key = key,
            });

            return await s3.DeleteObjectsAsync(request);
        }
    }
}
