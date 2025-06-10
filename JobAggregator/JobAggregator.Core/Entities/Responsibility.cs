using JobAggregator.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities;

public class Responsibility : Entity, IHandbook
{
    [Required]
    public string Name { get; set; }
    public int VacancyId { get; set; }
}
