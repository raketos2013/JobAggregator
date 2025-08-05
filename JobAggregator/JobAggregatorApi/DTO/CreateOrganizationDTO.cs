namespace JobAggregator.Api.DTO;

public class CreateOrganizationDTO
{
    public int UserId {  get; set; }
    public OrganizationDTO Organization { get; set; }
}
