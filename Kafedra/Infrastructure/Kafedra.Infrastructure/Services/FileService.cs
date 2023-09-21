using Kafedra.Application.Abstractions.Storages;
using Kafedra.Application.Utilities;
using Kafedra.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public void DeleteAsync(string root, string folder, string filename)
        {
            string path = Path.Combine(root, folder, filename);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        public async Task<string> UploadAsync(string path, IFormFile formFile)
        {
            string fileName = formFile.FileName;

            if (formFile.FileName.Length > 64)
            {
                fileName = formFile.FileName.Substring(0, 64);
            }

            fileName = Guid.NewGuid().ToString() + fileName;

            path += fileName;

            FileStream stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);

            return fileName;
        }

        public bool CheckImageValid(IFormFile file, int size , ref string _returnMessage , params string[] type)
        {
            if (!Extension.CheckSize(file, size))
            {
                _returnMessage = $"The size of this photo is {size}";
                return false;
            }

            for (int i = 0; i < type.Length; i++)
            {
                if (!Extension.CheckType(file, type[i]))
                {
                    _returnMessage = "The type is not correct";
                    return false;
                }
            }
           
            return true;
        }
    }
}
