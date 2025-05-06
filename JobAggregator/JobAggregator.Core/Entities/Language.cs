using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Length(2, 2)]
        public string Code { get; set; }
    }
}
