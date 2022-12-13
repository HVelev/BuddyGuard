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

            var objects = await s3.ListObjectsAsync("buddyguard");

            List<ImageDTO> images = new List<ImageDTO>();

            foreach (var obj in objects.S3Objects)
            {
                var image = await s3.GetObjectAsync("buddyguard", obj.Key);

                using (Stream responseStream = image.ResponseStream)
                {
                    images.Add(new ImageDTO
                    {
                        Name = image.Key,
                        Image = ReadStream(responseStream)
                    });
                }
            }

            return images;
        }

        public static byte[] ReadStream(Stream responseStream)
        {
            byte[] buffer = new byte[responseStream.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
