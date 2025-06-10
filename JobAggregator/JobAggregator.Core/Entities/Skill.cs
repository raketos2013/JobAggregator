using JobAggregator.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities;

public class Skill : Entity, IHandbook
{
    [Required]
    public string Name { get; set; }
    public List<Vacancy>? Vacancies { get; set; }
    public List<Resume>? Resumes { get; set; }
}
