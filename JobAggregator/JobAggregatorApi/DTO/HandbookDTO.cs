using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Api.DTO;

public class HandbookDTO
{
    [Required]
    public string Name { get; set; }
}
