namespace ITCPBackend.Model
{
    public class ProjectCost
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? CostDescription { get; set; }
    }
}
