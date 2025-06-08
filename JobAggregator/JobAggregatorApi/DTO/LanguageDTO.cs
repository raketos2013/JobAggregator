using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Api.DTO;

public class LanguageDTO
{
    [Required]
    public string Name { get; set; }
    [Length(2, 2)]
    public string Code { get; set; }
}
