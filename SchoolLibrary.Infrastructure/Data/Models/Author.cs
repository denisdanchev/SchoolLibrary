using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SchoolLibrary.Infrastructure.Constants.DataConstants;

namespace SchoolLibrary.Infrastructure.Data.Models
{
    [Index(nameof(AuthorName), IsUnique = true)]
    [Comment("Author")]
    public class Author
    {
        [Key]
        [Comment("Author identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Author name")]
        [MaxLength(AuthorNameMaxLenght)]
        public string AuthorName { get; set; } = string.Empty;

        [Comment("User identifier")]

        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
