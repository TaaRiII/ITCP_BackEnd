namespace ITCPBackend.DTOs
{
    public class AddSustainabilityArrayDto
    {
        public string ProjectTitleArr { get; set; }
        public string CurrentStateArr { get; set; }
        public string DescribeArr { get; set; }
    }

    public class SustainabilityDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string strategy { get; set; }
        public string JobType { get; set; }
        public SustainabilityDetailDto sustainabilityDetail { get; set; }
    }

    public class SustainabilityDetailDto
    {
        public string ProjectTitle { get; set; }
        public string CurrentState { get; set; }
        public string Describe { get; set; }
        public List<AddSustainabilityArrayDto> addSustainabilityArray { get; set; }
    }
}
