namespace ITCPBackend.DTOs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AddSustainabilityArrayDto
    {
        public string ProjectTitleArr { get; set; }
        public string CurrentStateArr { get; set; }
        public string DescribeArr { get; set; }
    }

    public class SustainabilityDto
    {
        public int? Id { get; set; }
        public int? ProjectId { get; set; }
        public string strategy { get; set; }
        public int? JobType { get; set; }
        public SustainabilityDetailDto sustainabilityDetail { get; set; }
    }

    public class SustainabilityDetailDto
    {
        public string strategy { get; set; }
        public string JobType { get; set; }
        public List<AddSustainabilityArrayDto> addSustainabilityArray { get; set; }
    }

}
