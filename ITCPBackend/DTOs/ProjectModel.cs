namespace ITCPBackend.DTOs
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string? MDA { get; set; }
        public string? BudgetCode { get; set; }
        public int MDASector { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectObjectives { get; set; }
        public string? ProjectDescription { get; set; }
        public string? ProjectClassification { get; set; }
    }
}
