using Kafedra.Domain.Entities;


namespace Kafedra.Application.DTOs.SubjectDTOs
{
    public class SubjectCreateDto
    {
        public string Name { get; set; }
        public ICollection<UserSubject> UserSubjects { get; set; }
        public ICollection<SubjectQualification> SubjectQualifications { get; set; }
        public int CurriculumId { get; set; }
    }
}
