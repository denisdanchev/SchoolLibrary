using SchoolLibrary.Core.Models.Book;
using SchoolLibrary.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableBookExtension
    {
        public static IQueryable<BookServiceModel> ProjectToBookServiceModel(this IQueryable<Book> books)
        {
            return books.Select(b => new BookServiceModel()
            {
                Id = b.Id,
                PositionInLibrary = b.PositionInLibrary,
                ImageUrl = b.ImageUrl,
                IsTaked = b.TakerId != null,
                Title = b.BookTitle,
                Pages = b.BookPages,
            });
        }
    }
}
