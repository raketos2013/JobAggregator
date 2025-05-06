using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Organization>? Organizations { get; set; }
    }
}
