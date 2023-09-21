using Kafedra.Domain.Entities.Common;


namespace Kafedra.Domain.Entities
{
    public class Dissertation:BaseEntity
    {
        public string Name { get; set; }
        public bool FromBachalavr { get; set; }
        public ICollection<UserDissertation> UserDissertations { get; set; }

    }
}
