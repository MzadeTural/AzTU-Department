using Microsoft.AspNetCore.Http;

namespace Kafedra.Application.ViewModel.Event
{
    public class CreateEventVM
    {
        public int Id { get; set; }
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
