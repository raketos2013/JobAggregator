using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Api.DTO;

public class OrganizationDTO
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Website { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    public string? Address { get; set; }
    public List<HandbookDTO>? Activities { get; set; }

}
