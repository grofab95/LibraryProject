using Library.Api.Handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageHandler _imageHandler;

        public ImagesController(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {
            try
            {
                var file = HttpContext.Request.Form.Files.FirstOrDefault();
                var uploadStatus = await _imageHandler.UploadImage(file);
                var uploadStatusTxt = uploadStatus.ToString();
                if (uploadStatusTxt == "Invalid")
                {
                    return BadRequest("Niepoprawny format pliku");
                }
                else
                {
                    return Ok(new { ImagePath = uploadStatus });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult RemoveImage(string imageName)
        {
            throw new NotImplementedException();
        }
    }
}