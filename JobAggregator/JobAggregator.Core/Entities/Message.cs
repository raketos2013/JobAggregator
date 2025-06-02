using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities;

public class Message : Entity
{
    [Required]
    public string Text { get; set; }
    public DateTime Created { get; set; }
    public int UserId { get; set; }
    public int ChatId { get; set; }
}
