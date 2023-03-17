namespace ITCPBackend.Model
{
    public class ProjectRate
    {
        public int Id { get; set; }
        public int projectId { get; set; }
        public int committeeId { get; set; }
        public int rate { get; set; }
    }
}
