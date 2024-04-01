using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolLibrary.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Infrastructure.Data.SeedDb
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(b => b.Author)
              .WithMany(g => g.Books)
              .HasForeignKey(b => b.AuthorId)
              .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Book[] { data.FirstBook, data.SecondBook, data.ThirdBook });
        }
    }
}
