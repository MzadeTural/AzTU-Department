using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Exceptions
{
    public class FileTypeException:Exception
    {
        public FileTypeException(string message) : base(message) { }

    }
}
