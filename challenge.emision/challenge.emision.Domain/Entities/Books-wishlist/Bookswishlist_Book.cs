using challenge.emision.domain.Contracts;

namespace challenge.emision.domain.Entities
{
    public class Bookswishlist_Book : AuditableEntity<int>
    {
        public int IdBookswishlist { get; set; }
        public string? IdBook { get; set; }
        public int NumberBook { get; set; }
    }
}
