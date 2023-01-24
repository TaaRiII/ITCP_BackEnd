namespace ITCPBackend.DTOs
{
    public class ProjectScopeModel
    {
        public int? Id { get; set; }
        public ValueKind? Deliverable { get; set; }
        public ValueKind? Milestone { get; set; }
        public int? ProjectId { get; set; }
        public string? accesstoken { get; set; }
    }
}
