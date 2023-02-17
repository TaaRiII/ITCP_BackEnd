namespace ITCPBackend.DTOs
{
    public class NotificationModelForResponce
    {
        public int Id { get; set; }
        public string? Msg { get; set; }
        public int? NotificationTime { get; set; }
        public int? ToID { get; set; }
        public int? FromID { get; set; }
        public int? Status { get; set; }
        public int? ProjectId { get; set; }
        public string? NotificationName { get; set; }
        public string? SenderName { get; set; }
        public string? ProjectName { get; set; }
    }
}
