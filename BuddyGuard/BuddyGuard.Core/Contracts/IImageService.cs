using Amazon.S3.Model;
using BuddyGuard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Contracts
{
    public interface IImageService
    {
        Task<HttpStatusCode> AddImage(EditImageDTO image);

        Task<List<ImageDTO>> GetImages();

        Task DeleteImage(string key);
    }
}
