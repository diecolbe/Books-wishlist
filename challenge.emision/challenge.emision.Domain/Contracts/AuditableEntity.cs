using challenge.emision.domain.Interfaces.Audit;
using System.ComponentModel.DataAnnotations.Schema;

namespace challenge.emision.domain.Contracts
{
    public abstract class AuditableEntity<TId> : IAuditableEntity<TId>
    {
        [NotMapped]
        public TId? Id { get; set; }
        [NotMapped]
        public string? CreatedBy { get; set; }
        [NotMapped]
        public DateTime CreatedOn { get; set; }
        [NotMapped]
        public string? LastModifiedBy { get; set; }
        [NotMapped]
        public DateTime? LastModifiedOn { get; set; }
    }
}
