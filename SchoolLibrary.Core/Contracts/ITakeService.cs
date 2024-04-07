using SchoolLibrary.Core.Models.Administrator;

namespace SchoolLibrary.Core.Contracts
{
    public interface ITakeService
    {
        Task<IEnumerable<TakeServiceModel>> AllAsync();
    }
}
