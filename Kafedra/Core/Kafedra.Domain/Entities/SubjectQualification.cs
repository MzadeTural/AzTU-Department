


namespace Kafedra.Domain.Entities
{
    public class SubjectQualification
    {
        public int Id { get; set; }


        public int SubejectId { get; set; }

        public Subject Subject { get; set; }
        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }
    }
}
