using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static SchoolLibrary.Infrastructure.Constants.DataConstants;

namespace SchoolLibrary.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLenght)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLenght)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        public Author? Author { get; set; }
    }
}
