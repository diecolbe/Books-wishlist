using challenge.emision.domain.Contracts;

namespace challenge.emision.domain.Entities
{
    public class Book : AuditableEntity<int>
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
    }
}
