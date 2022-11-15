namespace ITCPBackend.DTOs
{
    public class FileUploadModel
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public IFormFile? BPP { get; set; }
        public IFormFile? PENCOM { get; set; }
        public IFormFile? ITF { get; set; }
        public IFormFile? NSITF { get; set; }
        public IFormFile? AUDITED { get; set; }
        public IFormFile? CAC { get; set; }
        public IFormFile? PC { get; set; }
        public IFormFile? CV { get; set; }
    }
}
