using Kafedra.Persistence.Configurations;
using Kafedra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KafedraContext>
    {
        public KafedraContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<KafedraContext> builder = new();
            builder.UseSqlServer(ServiceConfiguration.ConnectionString());
            
            return new KafedraContext(builder.Options);
        }
    }
}
