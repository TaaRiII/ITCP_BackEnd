using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCPBackend.Model
{
    public class BussinessType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client client { get; set; }
        public int? status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
