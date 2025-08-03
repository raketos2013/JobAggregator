using JobAggregator.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobAggregator.Core.Entities;

public class Skill : Entity, IHandbook
{
    [Required]
    public string Name { get; set; }
    [JsonIgnore]
    public List<Vacancy>? Vacancies { get; set; }
    [JsonIgnore]
    public List<Resume>? Resumes { get; set; }
}
