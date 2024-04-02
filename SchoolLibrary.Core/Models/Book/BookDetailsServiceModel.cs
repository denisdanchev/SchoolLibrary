using SchoolLibrary.Core.Models.Author;

namespace SchoolLibrary.Core.Models.Book
{
    public class BookDetailsServiceModel : BookServiceModel
    {
        public string Description { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public AuthorServiceModel Author { get; set; } = null!;
    }
}
