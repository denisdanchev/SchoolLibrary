using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SchoolLibrary.Infrastructure.Constants.DataConstants;

namespace SchoolLibrary.Infrastructure.Data.Models
{
    [Comment("Genre")]
    public class Genre
    {
        [Key]
        [Comment("Genre identifier")]
        public int Id { get; set; }

        [Comment("Genre name")]
        [Required]
        [MaxLength(GenreNameMaxLenght)]
        public string GenreName { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
