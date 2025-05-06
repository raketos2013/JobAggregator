using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
    }
}
