using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Vacancy>? Vacancies { get; set; }
        public List<Resume>? Resumes { get; set; }
    }
}
 