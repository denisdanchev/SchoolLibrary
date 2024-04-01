using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Infrastructure.Common;
using SchoolLibrary.Infrastructure.Data.Models;

namespace SchoolLibrary.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository repository;
        public AuthorService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId, string userName)
        {
            await repository.AddAsync(new Author
            {
                UserId = userId,
                AuthorName = userName,
            });

            await repository.SaveChangesAsync();

        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Author>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> UserHasTakesAsync(string userId)
        {
            return await repository.AllReadOnly<Book>()
                .AnyAsync(b => b.TakerId == userId);
        }

        public async Task<bool> UserWithThisNameExistAsync(string username)
        {
            return await repository.AllReadOnly<Author>()
                .AnyAsync(a => a.AuthorName == username);
        }

        Task IAuthorService.UserWithThisNameExistAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
