using JobAggregator.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities;

public class Activity : Entity, IHandbook
{
    [Required]
    public string Name { get; set; }
    public List<Organization>? Organizations { get; set; }
}
