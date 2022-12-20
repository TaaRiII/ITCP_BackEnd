namespace ITCPBackend.Model
{
    public class ProjectDuration
    {
        public int Id { get; set; }
        public string? DurationType { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
