using Kafedra.Domain.Entities.Common;

namespace Kafedra.Domain.Entities
{
    public class Announcement:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
