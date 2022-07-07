using challenge.emision.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace challenge.emision.EF.EntityMappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("BOOK");

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(p => p.Title)
                .HasColumnName("TITLE")
                .IsRequired();

            builder.Property(p => p.Author)
                .HasColumnName("AUTHOR")
                .IsRequired();

            builder.Property(p => p.Publisher)
                .HasColumnName("PUBLISHER")
                .IsRequired();

            builder.HasKey(p => p.Id);
        }
    }
}
