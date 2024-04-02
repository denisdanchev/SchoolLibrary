using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Enumerations;
using SchoolLibrary.Core.Models.Book;
using SchoolLibrary.Infrastructure.Common;
using SchoolLibrary.Infrastructure.Data.Models;
using System.Linq;

namespace SchoolLibrary.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository repository;
        public BookService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<BookQueryServiceModel> AllAsync(
            string? genre = null,
            string? searchedTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 1
            )
        {
            var booksToShow = repository.AllReadOnly<Book>();

            if (genre != null)
            {
                booksToShow = booksToShow.Where(b => b.Genre.GenreName == genre);
            }

            if (searchedTerm != null)
            {
                string normalizedSearchedTerm = searchedTerm.ToLower();
                booksToShow = booksToShow
                    .Where(b => (b.BookTitle.ToLower().Contains(normalizedSearchedTerm) ||
                                 b.PositionInLibrary.ToLower().Contains(normalizedSearchedTerm) ||
                                 b.Description.ToLower().Contains(normalizedSearchedTerm)));
            }

            booksToShow = sorting switch
            {
                BookSorting.Title => booksToShow
                .OrderBy(b => b.BookTitle),
                BookSorting.NotTaked => booksToShow
                    .OrderBy(b => b.TakerId != null)
                    .ThenByDescending(b => b.Id),
                _ => booksToShow
                    .OrderByDescending(b => b.Id)
            };

            var books = await booksToShow
                .Skip((currentPage - 1) * booksPerPage)
                .Take(booksPerPage)
                .ProjectToBookServiceModel()
                .ToListAsync();

            int totalBooks = await booksToShow.CountAsync();

            return new BookQueryServiceModel()
            {
                Books = books,
                TotalBooksCount = totalBooks
            };
        }

        public async Task<IEnumerable<BookServiceModel>> AllBooksByAuthorId(int authorId)
        {
            return await repository.AllReadOnly<Book>()
                .Where(b => b.AuthorId == authorId)
                .ProjectToBookServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<BookServiceModel>> AllBooksByUserId(string userId)
        {
            return await repository.AllReadOnly<Book>()
                  .Where(b => b.TakerId == userId)
                  .ProjectToBookServiceModel()
                  .ToListAsync();
        }

        public async Task<IEnumerable<BookGenreServiceModel>> AllGenresAsync()
        {
            return await repository.AllReadOnly<Genre>()
               .Select(g => new BookGenreServiceModel()
               {
                   Id = g.Id,
                   Name = g.GenreName
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllGenresNamesAsync()
        {
            return await repository.AllReadOnly<Genre>()
                .Select(g => g.GenreName)
                .Distinct()
                .ToListAsync();
        }

        public async Task<int> CreateAsyc(BookFormModel model, int authorId)
        {
            Book book = new Book()
            {
                BookTitle = model.Title,
                ImageUrl = model.ImageUrl,
                BookPages = model.BookPages,
                PositionInLibrary = model.PositionInLibrary,
                Description = model.Description,
                GenreId = model.GenreId,
                AuthorId = authorId,
                TakerId = null
            };

            await repository.AddAsync(book);
            await repository.SaveChangesAsync();

            return book.Id;

        }

        public Task<bool> GenreExistAsync(int genreId)
        {
            return repository.AllReadOnly<Genre>()
                .AnyAsync(g => g.Id == genreId);
        }
    }
}
