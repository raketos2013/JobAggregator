using JobAggregator.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities;

public class Requirement : Entity, IHandbook
{
    [Required]
    public string Name { get; set; }
    public int VacancyId { get; set; }
}
