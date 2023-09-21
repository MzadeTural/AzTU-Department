using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence.Configurations
{
    public static class ServiceConfiguration
    {

        public static string ConnectionString()
        {

            ConfigurationManager manager = new ConfigurationManager();
            manager.SetBasePath(Directory.GetCurrentDirectory() + "../../../Presentation/Kafedra.MVC");
            manager.AddJsonFile("appsettings.json");
            return manager.GetConnectionString("Default");
        }

    }
}
