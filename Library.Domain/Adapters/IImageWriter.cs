using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Library.Api.Adapters
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file);
        Task<string> RemoveImage(string imageName);
    }
}
