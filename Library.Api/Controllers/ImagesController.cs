using System;
using System.Text.Json;
using System.Threading.Tasks;
using Library.Api.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/image")]
    public class ImagesController : Controller
    {
        private readonly IImageHandler _imageHandler;

        public ImagesController(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var uploadStatus = await _imageHandler.UploadImage(file);
            var uploadStatusTxt = uploadStatus.ToString();
            if (uploadStatusTxt == "Invalid")
            {
                return BadRequest("Invalid file format");
            }
            else
            {
                return uploadStatus;
            }
        }

        [HttpDelete]
        public IActionResult RemoveImage(string imageName)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetImageName()
        {
            var file = FileUtility.ReadFile();

            if (file == null)
            {
                FileUtility.SaveFile(string.Empty);
                return BadRequest();
            }
            
            var imageName = JsonSerializer.Deserialize<ImageName>(file);
            FileUtility.SaveFile(string.Empty);
            return Ok(imageName);
        }
    }
}