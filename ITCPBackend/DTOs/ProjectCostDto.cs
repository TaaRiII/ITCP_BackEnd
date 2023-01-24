namespace ITCPBackend.DTOs
{
    public class ProjectCostDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public IList<CostDetailDto> CostDetails { get; set; }
        public string? accesstoken { get; set; }
    }
}
