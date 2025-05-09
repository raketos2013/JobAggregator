using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Api.DTO
{
    public class RoleDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
