using challenge.emision.domain.Contracts;

namespace challenge.emision.domain.Entities
{
    public class Bookswishlist : AuditableEntity<int>
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public DateTime? CreationDate { get; set; }
        public int NumberBookswishlist { get; set; }
    }
}
