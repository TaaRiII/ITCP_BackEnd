namespace ITCPBackend.Model
{
    public class GenComInfo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PrimaryContactPersonName { get; set; }
        public long PrimaryContactPersonMobile { get; set; }
        public long TelPhone { get; set; }
        public string Email { get; set; }
        public string CoporateHeadQuater { get; set; }
        public int State { get; set; }
        public string OfficeLocation { get; set; }
        public int RCNumber { get; set; }
        public string NameOfCEO { get; set; }
        public long CEOPhoneNo { get; set; }
        public string CEOEmail { get; set; }
        public int ClientId { get; set; }
        public int status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
