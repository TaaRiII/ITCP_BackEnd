using MessagePack;

namespace ITCPBackend.Model
{
    public class FileUpload
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string? BPP { get; set; }
        public string? PENCOM { get; set; }
        public string? ITF { get; set; }
        public string? NSITF { get; set; }
        public string? AUDITED { get; set; }
        public string? CAC { get; set; }
        public string? PC { get; set; }
        public string? CV { get; set; }
    }
}
