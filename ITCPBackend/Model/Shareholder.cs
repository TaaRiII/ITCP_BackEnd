namespace ITCPBackend.Model
{
    public class Shareholder
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Nationality { get; set; }
        public string? Address { get; set; }
        public int? PerShares { get; set; }
        public int? ClientId { get; set; }
        public int? status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
