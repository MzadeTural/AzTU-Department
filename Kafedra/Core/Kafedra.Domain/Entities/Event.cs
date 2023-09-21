using Kafedra.Domain.Entities.Common;

namespace Kafedra.Domain.Entities
{
    public class Event:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
