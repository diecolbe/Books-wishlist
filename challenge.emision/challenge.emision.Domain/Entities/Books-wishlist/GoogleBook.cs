namespace challenge.emision.domain.Entities
{
    public class GoogleBook
    {
        public string? Id { get; set; }
        public string? Title { get; set; }       
        public string? Description { get; set; }
        public List<string>? Authors { get; set; }
        public string? Publisher { get; set; }       
    }
}
