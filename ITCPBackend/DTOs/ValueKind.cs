namespace ITCPBackend.DTOs
{
    public class ValueKind
    {
        public string? name { get; set; }
        public string? mile { get; set; }
        public IList<Quantity>? quantities { get; set; }
        public IList<Quantity>? milestone { get; set; }
    }
    public class Quantity
    {
        public string? qty { get; set; }
        public string? mil { get; set; }
    }
}
