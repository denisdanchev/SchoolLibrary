using SchoolLibrary.Core.Models.Administrator.User;

namespace SchoolLibrary.Core.Contracts
{
    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);

        Task<IEnumerable<UserServiceModel>> AllAsync();
        
    }
}
