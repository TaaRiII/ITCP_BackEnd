namespace ITCPBackend.DTOs
{
    public class CostDetailsDto
    {
        public string costdescription { get; set; }
        public string costamount { get; set; }
        public List<ExtracostDto> extracosts { get; set; }
    }

    public class ExtracostDto
    {
        public string description { get; set; }
        public string amount { get; set; }
    }

    public class CostDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public CostDetailsDto costDetails { get; set; }
    }

}
