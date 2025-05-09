using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities
{
    public class Chat : Entity
    {
        [Required]
        public string Name { get; set; }
        public User User1 { get; set; }
        public User User2 { get; set; }
        public List<Message>? Messages { get; set; }
    }
}
