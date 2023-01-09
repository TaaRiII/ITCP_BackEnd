namespace ITCPBackend.DTOs
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public long? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? role { get; set; }
        public int? Status { get; set; }
    }
}
