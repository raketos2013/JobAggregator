using JobAggregator.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Api.DTO;

public class HandbookDTO : IHandbook
{
    [Required]
    public string Name { get; set; }
}
