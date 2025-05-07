using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Role : Entity
    {
        [Required]
        public string Name { get; set; }
        public List<User>? Users { get; set; }
    }
}
