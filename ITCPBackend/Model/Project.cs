namespace ITCPBackend.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string MDA { get; set; }
        public string BudgetCode { get; set; }
        public int MDASector { get; set; }
        public int ClientId { get; set; }
          // 1=Submited By EntryUser
          // 2=MDA submit
          // 3=MDA Reject
          // 4=Sectrait submit
          // 5=Sectrait reject
        public int Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
