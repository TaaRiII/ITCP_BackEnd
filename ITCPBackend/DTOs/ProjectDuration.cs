namespace ITCPBackend.DTOs
{
    public class ProjectDurationModel
    {
        public int Id { get; set; }
        public string? DurationType { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
