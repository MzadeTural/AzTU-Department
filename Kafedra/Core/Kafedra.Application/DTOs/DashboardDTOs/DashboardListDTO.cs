using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.DTOs.DashboardDTOs
{
    public class DashboardListDTO
    {
        public int AztuUserCount { get; set; }
        public int AllUserCount { get; set; }
        public int InActiveUserCount { get; set; }
        public Dictionary<string,string> Setting { get; set; }
    }
}
