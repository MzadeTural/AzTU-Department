using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Utilities.File
{
    public static class Extension
    {
        public static bool CheckFileType(this IFormFile file, string typ)
        {
            return file.ContentType.Contains(typ);
        }
        public static bool CheckFileSize(this IFormFile file, int kb)
        {
            return file.Length / 1024 <= kb;
        }

        public static async Task<string> SaveFile(this IFormFile file, string root, string mfolder, string folder)
        {
            string folderPath = Path.Combine(mfolder, folder);
            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string resultPath = Path.Combine(root, folderPath, fileName);
            using (FileStream stream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
        public static async Task<string> SaveFile(this IFormFile file, string root, string mainfolder, string subfolder,string folder)
        {
            string folderPath = Path.Combine(mainfolder, subfolder,folder);
            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string resultPath = Path.Combine(root, folderPath, fileName);
            using (FileStream stream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}
