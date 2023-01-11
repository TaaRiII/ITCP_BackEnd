namespace ITCPBackend.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string? MDA { get; set; }
        public string? BudgetCode { get; set; }
        public int MDASector { get; set; }
        public int ClientId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
