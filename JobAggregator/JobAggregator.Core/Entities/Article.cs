using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<Comment>? Comments { get; set; }

    }
}
