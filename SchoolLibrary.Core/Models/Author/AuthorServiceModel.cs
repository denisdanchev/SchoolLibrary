using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Core.Models.Author
{
    public class AuthorServiceModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Author name")]
        public string AuthorName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
