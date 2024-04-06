using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SchoolLibrary.Infrastructure.Constants.DataConstants;

namespace SchoolLibrary.Infrastructure.Data.Models
{
    [Comment("Book")]
    public class Book
    {
        [Key]
        [Comment("Book identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Book title")]
        [MaxLength(BookTitleMaxLenght)]
        public string BookTitle { get; set; } = string.Empty;

        [Required]
        [Comment("Book image URL")]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        [Comment("Book pages number")]
        [Range(BookPagesMinCount, BookPagesMaxCount)]
        public int BookPages { get; set; }

        [Required]
        [Comment("Exact position in row")]
        [MaxLength(MaxLengthBookPositionInLibrary)]
        public string PositionInLibrary { get; set; } = string.Empty;

        [Required]
        [Comment("Book description")]
        [MaxLength(BookDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Genre identifier")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        [Required]
        [Comment("Author identifier")]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = null!;

        [Comment("Book taker identifier")]
        public string? TakerId { get; set; } = string.Empty;

        [Comment("Is book approved by admin")]
        public bool IsApproved { get; set; }

    }
}
