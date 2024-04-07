using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Administrator;
using SchoolLibrary.Infrastructure.Common;
using SchoolLibrary.Infrastructure.Data.Models;

namespace SchoolLibrary.Core.Models.Statistics
{
    public class TakeService : ITakeService
    {
        private readonly IRepository repository;
        public TakeService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<TakeServiceModel>> AllAsync()
        {

            return await repository.AllReadOnly<SchoolLibrary.Infrastructure.Data.Models.Book>()
                .Where(b => b.TakerId != null)
                .Include(b => b.Author)
                .Include(b => b.Taker)
                .Select(b => new TakeServiceModel()
                {
                    AuthorEmail = b.Author.User.Email,
                    AuthorFullName = $"{b.Author.User.FirstName} {b.Author.User.LastName}",
                    BookImageUrl = b.ImageUrl,
                    BookTitle = b.BookTitle,
                    TakerEmail = b.Taker != null ? b.Taker.Email : string.Empty,
                    TakerFullName = b.Taker != null ? $"{b.Taker.FirstName} {b.Taker.LastName}" : string.Empty
                })
                .ToListAsync();

        }
    }
}
