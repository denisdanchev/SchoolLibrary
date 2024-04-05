using SchoolLibrary.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static SchoolLibrary.Core.Constants.MessageConstants;
using static SchoolLibrary.Infrastructure.Constants.DataConstants;

namespace SchoolLibrary.Core.Models.Book
{
    public class BookFormModel : IBookModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BookTitleMaxLenght,
            MinimumLength = BookTitleMinLenght,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(BookPagesMinCount,BookPagesMaxCount)]
        public int BookPages { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [MaxLength(MaxLengthBookPositionInLibrary)]
        public string PositionInLibrary { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BookDescriptionMaxLength,
            MinimumLength = BookDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;

        [Display(Name = "Ganre")]
        public int GenreId { get; set; }
        public IEnumerable<BookGenreServiceModel> Genres { get; set; } = new List<BookGenreServiceModel>();

    }
}
