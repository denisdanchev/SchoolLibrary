using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Book;
using SchoolLibrary.Infrastructure.Common;
using SchoolLibrary.Infrastructure.Data.Models;

namespace SchoolLibrary.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository repository;
        public BookService(IRepository _repository)
        {
            repository = _repository;   
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

        public async Task<int> CreateAsyc(BookFormModel model, int authorId)
        {
            Book book = new Book()
            {
                BookTitle = model.Title,
                ImageUrl = model.ImageUrl,
                BookPages = model.BookPages,
                PositionInLibrary =model.PositionInLibrary,
                Description = model.Description,
                GenreId = model.GenreId,
                AuthorId = authorId,
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
