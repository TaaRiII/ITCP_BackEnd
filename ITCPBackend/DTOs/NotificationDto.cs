namespace ITCPBackend.DTOs
{
    public class NotificationDto
    {
        public int? Id { get; set; }
        public string Msg { get; set; }
        public DateTime? CratedDate { get; set; }
        public int ToID { get; set; }
        public int? FromID { get; set; }
        public int Status { get; set; }
    }
}
