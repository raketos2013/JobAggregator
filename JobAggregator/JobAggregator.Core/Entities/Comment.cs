using System.ComponentModel.DataAnnotations;

namespace JobAggregator.Core.Entities;

public class Comment : Entity
{
    public int UserId { get; set; }
    public int ArticleId { get; set; }
    [Required]
    public string Text { get; set; }
}
