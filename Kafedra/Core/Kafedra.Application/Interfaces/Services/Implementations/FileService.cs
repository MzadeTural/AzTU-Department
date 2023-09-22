using Kafedra.Application.Exceptions;
using Kafedra.Application.Interfaces.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Interfaces.Services.Implementations
{
    public class FileService : IFileService
    {
        public async Task<string> CreateFileAsync(IFormFile file, string path)
        {
            if (!file.ContentType.Contains("image/"))
            {
                throw new FileTypeException("But it can be in Image format");
            }
            if (file.Length / 1024 > 600)
            {
                throw new FileSizeException("Image size is too large");
            }
            string FileName = $"{Guid.NewGuid()}-{file.FileName}";
            string ResultPath = Path.Combine(path, FileName);
            using (FileStream fileStream = new FileStream(ResultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return FileName;

        }

        public void DeteleFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
