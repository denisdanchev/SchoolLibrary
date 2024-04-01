using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Infrastructure.Data.Models;

namespace SchoolLibrary.Infrastructure.Data
{
    public class SchoolLibraryDbContext : IdentityDbContext
    {
        public SchoolLibraryDbContext(DbContextOptions<SchoolLibraryDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Book>()
              .HasOne(b => b.Author)
              .WithMany(g => g.Books)
              .HasForeignKey(b => b.AuthorId)
              .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
