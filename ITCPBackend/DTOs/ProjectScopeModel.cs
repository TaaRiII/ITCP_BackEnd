namespace ITCPBackend.DTOs
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Detail
    {
        public string Deliverables { get; set; }
        public string Milestones { get; set; }
    }

    public class ProjectScopeModel
    {
        public int Id { get; set; }
        public ScopeDetail ScopeDetail { get; set; }
        public int ProjectId { get; set; }
    }

    public class ScopeDetail
    {
        public List<Detail> detail { get; set; }
    }




}
