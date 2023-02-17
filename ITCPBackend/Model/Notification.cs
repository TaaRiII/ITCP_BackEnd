namespace ITCPBackend.Model
{
    public class Notification
    {
        public int Id { get; set; } 
        public string Msg { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public int ToID { get; set; } 
        public int FromID { get; set; } 
        public int Status { get; set; } 
        public int ProjectId { get; set; }
        public string NotificationName { get; set; }  
    }
}
