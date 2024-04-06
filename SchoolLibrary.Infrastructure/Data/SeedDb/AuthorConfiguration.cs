using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolLibrary.Infrastructure.Data.Models;

namespace SchoolLibrary.Infrastructure.Data.SeedDb
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            var data = new SeedData();

            builder.HasData(new Author[] {data.Author, data.AdminAuthor });
        }
    }
}
