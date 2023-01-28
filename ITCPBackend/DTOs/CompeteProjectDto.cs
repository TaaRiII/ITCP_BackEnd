namespace ITCPBackend.DTOs
{
    public class CompeteProjectDto
    {
        public int? Id { get; set; }
        public string? MDA { get; set; }
        public string? BudgetCode { get; set; }
        public int? MDASector { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectObjectives { get; set; }
        public string? ProjectDescription { get; set; }
        public string? ProjectClassification { get; set; }
        public string? accesstoken { get; set; }
        public int? ProjectId { get; set; }
        public string? DurationType { get; set; }
        public string? FirstStartDate { get; set; }
        public string? FirstEndDate { get; set; }
        public string? SecondStartDate { get; set; }
        public string? SecondEndDate { get; set; }
        public string? ThirdStartDate { get; set; }
        public string? ThirdEndDate { get; set; }
        public string SustainabilityName { get; set; }
        public string? Details { get; set; }
        public string? Deliverable { get; set; }
        public string? Milestone { get; set; }
        public int? scopeId { get; set; }
        public int? durationId { get; set; }
        public int? sutainablityId { get; set; }
        public int? costId { get; set; }
        public string? jobType { get; set; }
        public string? costDetail { set; get; }
    }
}