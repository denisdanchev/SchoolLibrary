using SchoolLibrary.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Core.Models.Book
{
    public class AllBooksQueryModel
    {
        public int BooksPerPage { get; } = 3;

        public string Genre { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public BookSorting Sorting { get; init; }

        public int CurentPage { get; init; } = 1;

        public int TotalBooksCount { get; set; }

        public IEnumerable<string> Genres { get; set; } = null!;

        public IEnumerable<BookServiceModel> Books { get; set; } = new List<BookServiceModel>();

    }
}
