namespace ITCPBackend.Model
{
    public class Department
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public int? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
