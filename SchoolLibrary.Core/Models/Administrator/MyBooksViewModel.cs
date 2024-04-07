using SchoolLibrary.Core.Models.Book;

namespace SchoolLibrary.Core.Models.Administrator
{
    public class MyBooksViewModel
    {
        public IEnumerable<BookServiceModel> AddedBooks { get; set; } = new List<BookServiceModel>();
        public IEnumerable<BookServiceModel> TakedBooks { get; set; } = new List<BookServiceModel>();

    }
}
