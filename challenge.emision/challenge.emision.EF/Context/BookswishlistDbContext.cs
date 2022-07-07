using challenge.emision.domain.Entities;
using challenge.emision.EF.EntityMappings;
using Microsoft.EntityFrameworkCore;

namespace challenge.emision.EF.Context
{
    public class BookswishlistDbContext : DbContext
    {
        public BookswishlistDbContext(DbContextOptions<BookswishlistDbContext> dbContextOptions)
          : base(dbContextOptions)
        {

        }

        public DbSet<Bookswishlist> Bookswishlist { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Bookswishlist_Book> Bookswishlist_Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookswishlistMapping());
            modelBuilder.ApplyConfiguration(new BookMapping());
            modelBuilder.ApplyConfiguration(new Bookswishlist_BookMapping());
        }
    }
}
