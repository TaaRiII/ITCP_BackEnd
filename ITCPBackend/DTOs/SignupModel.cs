namespace ITCPBackend.DTOs
{
    public class SignupModel
    {
        public string? Name { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
        public int? status { get; set; }
        public int? MDAId { get; set; }
    }
}
