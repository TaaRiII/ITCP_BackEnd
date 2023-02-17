using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ITCPBackend.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
        public int? status { get; set; }
        public int? MDAId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
