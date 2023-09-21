using Kafedra.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence.Concretes.Services
{
   
        public class LayoutServices
        {
            private readonly KafedraContext _context;

            public LayoutServices(KafedraContext context)
            {
                _context = context;
            }
            public Dictionary<string, string> GetSetting()
            {
                return _context.Settings.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
            }
        }
    
}
