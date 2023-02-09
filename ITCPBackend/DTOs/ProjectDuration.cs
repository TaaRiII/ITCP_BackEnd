namespace ITCPBackend.DTOs
{
    public class ProjectDurationModel
    {
        public int Id { get; set; }
        public string? DurationType { get; set; }
        public int? ProjectId { get; set; }
        public string? FirstStartDate { get; set; }
        public string? FirstEndDate { get; set; }
        public string? SecondStartDate { get; set; }
        public string? SecondEndDate { get; set; }
        public string? ThirdStartDate { get; set; }
        public string? ThirdEndDate { get; set; }
    }
}
