namespace JobAggregator.Api.DTO;

public class QueryDTO
{
    public int Take { get; set; } = 20;
    public int Skip { get; set; } = 0;
    public string? SortColumn { get; set; } = "Id";
    public string? SearchTerm { get; set; }
    public bool IsAscending { get; set; } = true;
}
