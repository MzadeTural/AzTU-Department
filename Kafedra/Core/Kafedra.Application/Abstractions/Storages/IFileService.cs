using Kafedra.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Abstractions.Storages
{
    public interface IFileService
    {
        Task<string> UploadAsync(string path, IFormFile formFile);
        void DeleteAsync(string root, string folder, string filename);
        bool CheckImageValid(IFormFile file, int size, ref string _returnMessage, params string[] type);
    }
}
