using SchoolLibrary.Core.Models.Statistics;

namespace SchoolLibrary.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();

    }
}
