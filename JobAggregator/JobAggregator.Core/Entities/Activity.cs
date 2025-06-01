using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities;

public class Activity : Entity
{
    [Required]
    public string Name { get; set; }
    public List<Organization>? Organizations { get; set; }
}
