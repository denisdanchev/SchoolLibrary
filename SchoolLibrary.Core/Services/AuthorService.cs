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

        public Task CreateAsync(string userId, string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Author>()
                .AnyAsync(a => a.UserId == userId);
        }

        public Task<bool> UserHasTakesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task UserWithThisNameExistAsync(string username)
        {

        }
    }
}
