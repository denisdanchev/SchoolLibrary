using System.ComponentModel.DataAnnotations;
using static SchoolLibrary.Infrastructure.Constants.DataConstants;
using static SchoolLibrary.Core.Constants.MessageConstants;

namespace SchoolLibrary.Core.Models.Book
{
    public class BookServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BookTitleMaxLenght,
         MinimumLength = BookTitleMinLenght,
         ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(BookPagesMaxCount, BookPagesMinCount)]
        public int Pages { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [MaxLength(MaxLengthBookPositionInLibrary)]
        public string PositionInLibrary { get; set; } = string.Empty;


        [Display(Name = "Is book taked")]
        public bool IsTaked { get; set; }
    }
}