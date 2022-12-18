using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Http.Internal;
using System.Net;

namespace BuddyGuard.UnitTests
{
    [TestFixture]
    public class ImageServiceTests
    {
        private IImageService service;

        private EditImageDTO imageDto;

        [SetUp]
        public void Setup()
        {
            service = new ImageService();
        }

        [Test]
        public async Task AssertThatImageIsUploaded()
        {
            var files = Directory.GetFiles("../../../TestPictures");

            foreach (var filePath in files)
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open))
                {
                    imageDto = new EditImageDTO
                    {
                        Description = "Test",
                        Image = new FormFile(fs, 0, fs.Length, "Test", fs.Name),
                        Name = fs.Name
                    };

                    var response = await service.AddImage(imageDto);

                    Assert.That(response, Is.EqualTo(HttpStatusCode.OK));
                }
            }
        }

        [Test]
        public async Task AssertThatAllImagesAreReceived()
        {
            var images = await service.GetImages();

            var files = Directory.GetFiles("../../../TestPictures");

            foreach (var filePath in files)
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open))
                {
                    imageDto = new EditImageDTO
                    {
                        Description = "Test",
                        Image = new FormFile(fs, 0, fs.Length, "Test", fs.Name),
                        Name = fs.Name
                    };

                    var response = await service.AddImage(imageDto);
                }
            }

            var updatedImages = await service.GetImages();

            Assert.That(updatedImages.Count, Is.EqualTo(images.Count + 3));
        }

        [Test]
        public async Task AssertThatImageIsDeleted()
        {
            var files = Directory.GetFiles("../../../TestPictures");

            foreach (var filePath in files)
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open))
                {
                    imageDto = new EditImageDTO
                    {
                        Description = "Test",
                        Image = new FormFile(fs, 0, fs.Length, "Test", fs.Name),
                        Name = fs.Name
                    };

                    var response = await service.AddImage(imageDto);
                }
            }

            var images = await service.GetImages();

            await service.DeleteImage(images.First().Name);

            var updatedImages = await service.GetImages();

            Assert.That(updatedImages.Count, Is.EqualTo(images.Count - 1));
        }
    }
}
