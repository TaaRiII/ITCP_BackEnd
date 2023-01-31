namespace ITCPBackend.DTOs
{
    public class ProjectStatusUpdateDto
    {
        public int ProjectId { get; set; }
        public int NewStatus { get; set; }
        public string Note { get; set; }

    }
}
