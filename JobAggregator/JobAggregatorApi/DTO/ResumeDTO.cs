using JobAggregator.Core.Entities;
using JobAggregator.Core.Enum;

namespace JobAggregator.Api.DTO;

public class ResumeDTO
{
    public int UserId { get; set; }
    public string? Experience { get; set; }
    public string? Links { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string? Photo { get; set; }
    public List<LanguageDTO>? Languages { get; set; }
    public string? Education { get; set; }
    //public int CountViews { get; set; }
    //public int Priority { get; set; }
    //public DateTime Created { get; set; }
    public List<HandbookDTO>? Skills { get; set; }
}
