using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.ViewModel.AnnouncementVM
{
    public  class CreateAnnouncementsVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime  CreatedorUpdate { get; set; }=DateTime.Now;
    }
}
