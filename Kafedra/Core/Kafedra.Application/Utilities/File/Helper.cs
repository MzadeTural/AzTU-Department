using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Utilities.File
{
    public static class Helper
    {
        public static void RemoveFile(string root,string folder,string imageName)
        {
            var path = Path.Combine(root, folder, imageName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
