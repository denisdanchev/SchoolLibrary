using SchoolLibrary.Core.Models.Book;

namespace SchoolLibrary.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookGenreServiceModel>> AllGenresAsync();

        Task<bool> GenreExistAsync(int genreId);

        Task<int> CreateAsyc(BookFormModel model, int authorId);
    }
}
