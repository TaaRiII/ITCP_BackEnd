namespace ITCPBackend.Model
{
    public class ProjectScope
    {
        public int Id { get; set; }
        public string? Deliverable { get; set; }
        public string? Milestone { get; set; }
        public int ProjectId { get; set; }
    }
}
