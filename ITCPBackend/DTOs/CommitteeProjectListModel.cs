namespace ITCPBackend.DTOs
{
    public class CommitteeProjectListModel
    {
        public int? Id { get; set; }
        public DateTime ProjectCreated { get; set; }
        public string? MDA { get; set; }
        public string? BudgetCode { get; set; }
        public int? MDASector { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectObjectives { get; set; }
        public string? ProjectDescription { get; set; }
        public string? ProjectClassification { get; set; }
        public int ProjectStatus { set; get; }
        public string RejectNotes { set; get; }
        public string projectLevel { set; get; }
        public double? persentage { get; set; }
        public int? countCommittee { get; set; }
    }
}
