using challenge.emision.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace challenge.emision.EF.EntityMappings
{
    public class BookswishlistMapping : IEntityTypeConfiguration<Bookswishlist>
    {
        public void Configure(EntityTypeBuilder<Bookswishlist> builder)
        {
            builder.ToTable("BOOKSWISHLIST");

            builder.Property(p => p.Id)
                .HasColumnName("IDBOOKSWISHLIST")
                .IsRequired();

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(p => p.User)
                .HasColumnName("USER")
                .IsRequired();

            builder.Property(p => p.CreationDate)
                .HasColumnName("CREATIONDATE")
                .IsRequired();

            builder.Property(p => p.NumberBookswishlist)
                .HasColumnName("NUMBERBOOKSWISHLIST")
                .IsRequired();

            builder.HasKey(p => p.Id);
        }
    }
}
