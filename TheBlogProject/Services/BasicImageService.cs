using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProject.Services
{
    public class BasicImageService : IImageService
    {
        public string ContentType(IFormFile file)
        {
            return file?.ContentType;
        }

        public string DecodeImage(byte[] data, string type)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> EncodeImageAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> EncodeImageAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public int Size(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
