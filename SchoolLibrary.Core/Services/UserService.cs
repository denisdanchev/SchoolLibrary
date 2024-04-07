using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Administrator.User;
using SchoolLibrary.Infrastructure.Common;
using SchoolLibrary.Infrastructure.Data.Models;

namespace SchoolLibrary.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        public UserService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Include(u => u.Author)
                .Select(u => new UserServiceModel{
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    IsAuthor = u.Author != null
                }).ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
