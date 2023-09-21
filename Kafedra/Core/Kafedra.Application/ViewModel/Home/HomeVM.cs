using Kafedra.Domain.Entities;

namespace Kafedra.Application.ViewModel.Home
{
    public class HomeVM
    {
        public List<Slider> Sliders{ get; set; }
        public List<Kafedra.Domain.Entities.Event> Events{ get; set; }
        public Kafedra.Domain.Entities.Event Event { get; set; }
        public List<Announcement> Announcements{ get; set; }
        public List<Partners> Partners{ get; set; }
    }
}
