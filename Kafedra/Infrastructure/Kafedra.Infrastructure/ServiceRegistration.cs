using Kafedra.Application.Abstractions.Storages;
using Kafedra.Application.Abstractions.Storages.Local;
using Kafedra.Domain.Enums;
using Kafedra.Infrastructure.Services;
using Kafedra.Infrastructure.Services.Storages.Local;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<IFileService, FileService>();

        }

        public static void AddStorageType(this IServiceCollection services, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.ILocalStorage:
                    services.AddScoped<ILocalStorage, LocalStorage>();
                    break;
                default:
                    break;
            }
        }

    }
}
