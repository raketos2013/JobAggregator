using JobAggregator.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Api.DTO;

public class LanguageDTO : IHandbook
{
    [Required]
    public string Name { get; set; }
    [Length(2, 2)]
    public string Code { get; set; }
}
