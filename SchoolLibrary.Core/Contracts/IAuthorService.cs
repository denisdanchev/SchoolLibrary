namespace SchoolLibrary.Core.Contracts
{
    public interface IAuthorService
    {
        Task<bool> ExistByIdAsync(string userId);
        Task<bool> UserWithThisNameExistAsync(string username);
        Task<bool> UserHasTakesAsync(string userId);

        Task<int?> GetAuthorIdAsync(string userId);
        Task CreateAsync(string userId, string userName);

    }
}
