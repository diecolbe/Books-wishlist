using challenge.emision.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace challenge.emision.EF.EntityMappings
{
    public class Bookswishlist_BookMapping : IEntityTypeConfiguration<Bookswishlist_Book>
    {
        public void Configure(EntityTypeBuilder<Bookswishlist_Book> builder)
        {
            builder.ToTable("BOOKSWISHLIST_BOOK");

            builder.Property(p => p.IdBookswishlist)
                .HasColumnName("IDBOOKSWISHLIST")
                .IsRequired();

            builder.Property(p => p.IdBook)
                .HasColumnName("IDBOOK")
                .IsRequired();

            builder.HasKey(p => new { p.IdBookswishlist, p.IdBook });

        }
    }
}
