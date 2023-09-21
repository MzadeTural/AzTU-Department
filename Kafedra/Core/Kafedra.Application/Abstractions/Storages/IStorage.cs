using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Abstractions.Storages
{
    public interface IStorage
    {

        Task SaveFile();
        Task RemoveFile();

        //todo these methods will change or add some methods
    }
}
