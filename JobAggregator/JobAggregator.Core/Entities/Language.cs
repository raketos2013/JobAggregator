using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities;

public class Language : Entity
{
    [Required]
    public string Name { get; set; }
    [Length(2, 2)]
    public string Code { get; set; }
}
