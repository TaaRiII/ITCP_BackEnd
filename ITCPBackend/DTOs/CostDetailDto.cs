namespace ITCPBackend.DTOs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CostDetailsDto
    {
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
