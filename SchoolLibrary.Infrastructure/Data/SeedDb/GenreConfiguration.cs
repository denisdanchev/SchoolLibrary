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
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            var data = new SeedData();

            builder.HasData(new Genre[] {
                data.HorrorGenre,
                data.HistoryGenre,
                data.FantasyGenre,
                data.MysteryGenre,
                data.RomanticGenre 
            });
        }
    }
}
