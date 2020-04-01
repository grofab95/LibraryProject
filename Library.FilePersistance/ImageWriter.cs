using Library.Domain.Adapters;
using Library.FilePersistance.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.FilePersistance
{
    public class ImageWriter : IImageWriter
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }
            
            return "Invalid";
        }
        public async Task<string> RemoveImage(string imageName)
        {
            throw new NotImplementedException();
        }

        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }
                
        public async Task<string> WriteFile(IFormFile file)
        {
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; 
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\covers", fileName);

                var imageName = new ImageName
                {
                    Name = file.FileName,
                    FullName = fileName
                };

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

            return fileName;
        }
    }
}
