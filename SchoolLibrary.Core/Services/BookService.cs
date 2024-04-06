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
            var booksToShow = repository.AllReadOnly<Book>()
                .Where(b => b.IsApproved);

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
                .Where(b => b.IsApproved)
                .Where(b => b.AuthorId == authorId)
                .ProjectToBookServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<BookServiceModel>> AllBooksByUserId(string userId)
        {
            return await repository.AllReadOnly<Book>()
                  .Where(b => b.IsApproved)
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

        public async Task<BookDetailsServiceModel> BookDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Book>()
                .Where(b => b.IsApproved)
                .Where(b => b.Id == id)
                .Select(b => new BookDetailsServiceModel()
                {
                    Id = b.Id,
                    PositionInLibrary = b.PositionInLibrary,
                    Author = new Models.Author.AuthorServiceModel()
                    {
                        FullName = $"{b.Author.User.FirstName} {b.Author.User.LastName}",
                        Email = b.Author.User.Email,
                        AuthorName = b.Author.AuthorName
                    },
                    Genre = b.Genre.GenreName,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Title = b.BookTitle,
                    Pages = b.BookPages
                })
                .FirstAsync();
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

        public async Task DeleteAsync(int bookId)
        {
            await repository.DeleteAsync<Book>(bookId);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int bookId, BookFormModel model)
        {
            var book = await repository.GetByIdAsync<Book>(bookId);

            if (book != null)
            {
                book.PositionInLibrary = model.PositionInLibrary;
                book.GenreId = model.GenreId;
                book.Description = model.Description;
                book.ImageUrl = model.ImageUrl;
                book.BookTitle = model.Title;
                book.BookPages = model.BookPages;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Book>()
                .AnyAsync(b => b.Id == id);
        }

        public Task<bool> GenreExistAsync(int genreId)
        {
            return repository.AllReadOnly<Genre>()
                .AnyAsync(g => g.Id == genreId);
        }

        public async Task<BookFormModel?> GetBookFormModelByIdAsync(int id)
        {
            var book = await repository.AllReadOnly<Book>()
                .Where(b => b.IsApproved)
                .Where(b => b.Id == id)
                .Select(b => new BookFormModel()
                {
                    PositionInLibrary = b.PositionInLibrary,
                    GenreId = b.GenreId,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Title = b.BookTitle,
                    BookPages = b.BookPages
                })
                .FirstOrDefaultAsync();
            if (book != null)
            {
                book.Genres = await AllGenresAsync();
            }
            return book;
        }

        public async Task<bool> HasAuthorWithIdAsync(int bookId, string userId)
        {
            return await repository.AllReadOnly<Book>()
                .AnyAsync(b => b.Id == bookId && b.Author.UserId == userId);
        }

        public async Task<bool> IsTakedAsync(int bookId)
        {
            bool result = false;

            var book = await repository.GetByIdAsync<Book>(bookId);

            if (book != null)
            {
                result = book.TakerId != null;
            }

            return result;
        }

        public async Task<bool> IsTakedByUserWithIdAsync(int bookId, string userId)
        {
            bool result = false;

            var book = await repository.GetByIdAsync<Book>(bookId);

            if (book != null)
            {
                result = book.TakerId == userId;
            }

            return result;

        }

        public async Task TakeAsync(int bookId, string userId)
        {
            var book = await repository.GetByIdAsync<Book>(bookId);

            if (book != null)
            {
                book.TakerId = userId;
                await repository.SaveChangesAsync();        
            }
             
        }

        public async Task TakeBackAsync(int bookId, string userId)
        {
            var book = await repository.GetByIdAsync<Book>(bookId);

            if (book != null)
            {
                if (book.TakerId != userId)
                {
                    throw new UnauthorizedAccessException("The user does not take a book!");
                }
                book.TakerId = null;
                await repository.SaveChangesAsync();
            }
        }
    }
}
