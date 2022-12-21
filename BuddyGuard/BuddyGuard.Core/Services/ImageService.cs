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
using BuddyGuard.Core.Enums;
using BuddyGuard.Core.Data.Constants;

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
                || !Enum.IsDefined(typeof(ExtensionsEnum), extension.Remove(0, 1)))
            {
                throw new ArgumentException();
            }

            var awsKey = DataConstants.S3Constants.Key;
            var awsSecretKey = DataConstants.S3Constants.SecretKey;
            var bucketRegion = Amazon.RegionEndpoint.USEast1;
            var s3 = new AmazonS3Client(awsKey, awsSecretKey, bucketRegion);
            var putRequest = new PutObjectRequest();
            if (image.Description != null)
            {
                putRequest.TagSet.Add(new Tag
                {
                    Key = DataConstants.S3Constants.Descrpition,
                    Value = image.Description
                });
            }
            putRequest.BucketName = DataConstants.S3Constants.BucketName;
            putRequest.ContentType = "image/jpeg";
            putRequest.InputStream = image.Image.OpenReadStream();
            putRequest.Key = Guid.NewGuid().ToString("D");
            PutObjectResponse putResponse = await s3.PutObjectAsync(putRequest);
            return putResponse.HttpStatusCode;
        }

        public async Task<List<ImageDTO>> GetImages()
        {
            var awsKey = DataConstants.S3Constants.Key;
            var awsSecretKey = DataConstants.S3Constants.SecretKey;
            var bucketRegion = Amazon.RegionEndpoint.USEast1;
            var s3 = new AmazonS3Client(awsKey, awsSecretKey, bucketRegion);

            try
            {
                var images = new List<ImageDTO>();

                var objects = await s3.ListObjectsAsync(DataConstants.S3Constants.BucketName);

                foreach (var obj in objects.S3Objects.OrderByDescending(x => x.LastModified))
                {
                    var result = await s3.GetObjectAsync(DataConstants.S3Constants.BucketName, obj.Key);

                    if (result.Headers.ContentType != "image/jpeg")
                    {
                        continue;
                    }

                    var expires = DateTime.Now.AddHours(1);

                    GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
                    {
                        BucketName = DataConstants.S3Constants.BucketName,
                        Key = obj.Key,
                        Expires = expires,
                    };

                    var url = s3.GetPreSignedURL(request);

                    var tagRequest = new GetObjectTaggingRequest()
                    {
                        BucketName = DataConstants.S3Constants.BucketName,
                        Key = obj.Key
                    };

                    var response = await s3.GetObjectTaggingAsync(tagRequest);

                    var tag = response.Tagging.FirstOrDefault(x => x.Key == DataConstants.S3Constants.Descrpition);

                    string? description = null;

                    if (tag != null)
                    {
                        description = tag.Value;
                    }

                    images.Add(new ImageDTO
                    {
                        Name = request.Key,
                        ImageUrl = url,
                        Description = description
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
            var awsKey = DataConstants.S3Constants.Key;
            var awsSecretKey = DataConstants.S3Constants.SecretKey;
            var bucketRegion = Amazon.RegionEndpoint.USEast1;
            var s3 = new AmazonS3Client(awsKey, awsSecretKey, bucketRegion);


            var obj = await s3.GetObjectAsync(DataConstants.S3Constants.BucketName, key);


            var request = new DeleteObjectRequest
            {
                BucketName= DataConstants.S3Constants.BucketName,
                Key = key,
                VersionId = obj.VersionId,
            };

            await s3.DeleteObjectAsync(request);
        }
    }
}
