using Library.Api.Adapters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Handler
{
    public interface IImageHandler
    {
        Task<string> UploadImage(IFormFile file);
    }

    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            return await _imageWriter.UploadImage(file);
        }

        public async Task<IActionResult> RemoveImage(string imageName)
        {
            var result = await _imageWriter.RemoveImage(imageName);
            return new ObjectResult(result);
        }
    }
}
