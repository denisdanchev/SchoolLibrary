using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Core.Models.Author
{
    public class AuthorServiceModel
    {
        [Display(Name = "Author name")]
        public string AuthorName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
