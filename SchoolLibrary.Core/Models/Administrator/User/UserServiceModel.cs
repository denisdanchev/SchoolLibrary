using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Core.Models.Administrator.User
{
    public class UserServiceModel
    {
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Full name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsAuthor { get; set; }
    }
}
