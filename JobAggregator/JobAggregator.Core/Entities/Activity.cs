using JobAggregator.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobAggregator.Core.Entities;

public class Activity : Entity, IHandbook
{
    [Required]
    public string Name { get; set; }

    [JsonIgnore]
    public List<Organization>? Organizations { get; set; }
}
