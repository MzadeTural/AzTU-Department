using Kafedra.Application.Abstractions.Storages.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Infrastructure.Services.Storages.Local
{
    public class LocalStorage : ILocalStorage
    {
        public Task RemoveFile()
        {
            throw new NotImplementedException();
        }

        public Task SaveFile()
        {
            throw new NotImplementedException();
        }
    }
}
