namespace ITCPBackend.DTOs
{
    public class ValueKind
    {
        public string name { get; set; }
        public IList<Quantity> quantities { get; set; }
    }
    public class Quantity
    {
        public string qty { get; set; }
    }
}
