using System.ComponentModel.DataAnnotations;
using static SchoolLibrary.Infrastructure.Constants.DataConstants;
using static SchoolLibrary.Core.Constants.MessageConstants;

namespace SchoolLibrary.Core.Models.Author
{
    public class BeAuthorFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AuthorNameMaxLenght,
            MinimumLength = AuthorNameMinLenght,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Author name")]
        public string AuthorName { get; set; } = string.Empty;
    }
}
