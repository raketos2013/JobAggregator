using JobAggregator.Core.Enum;

namespace JobAggregator.Core.Entities;

public class Resume : Entity
{
    public int UserId { get; set; }
    public string? Experience { get; set; }
    public string? Links { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string? Photo { get; set; }
    public List<Language>? Languages { get; set; }
    public string? Education { get; set; }
    public int CountViews { get; set; }
    public int Priority { get; set; }
    public DateTime Created { get; set; }
    public List<Skill>? Skills { get; set; }
}
