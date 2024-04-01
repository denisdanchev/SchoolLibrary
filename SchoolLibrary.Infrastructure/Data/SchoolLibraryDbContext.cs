using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Infrastructure.Data.Models;
using SchoolLibrary.Infrastructure.Data.SeedDb;

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
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
