namespace SchoolLibrary.Core.Contracts
{
    public interface IAuthorService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<bool> UserHasTakesAsync(string userId);

        Task CreateAsync(string userId, string userName);
        Task UserWithThisNameExistAsync(string username);

    }
}
