using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Api.DTO;

public class UserDTO
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
}
