using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Statistics;
using SchoolLibrary.Infrastructure.Common;
using SchoolLibrary.Infrastructure.Data.Models;

namespace SchoolLibrary.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;
        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalBooks = await repository.AllReadOnly<Book>()
                .CountAsync();

            int totalTakes = await repository.AllReadOnly<Book>()
                .Where(b => b.TakerId != null)
                .CountAsync();

            return new StatisticServiceModel
            {
                TotalBooks = totalBooks,
                TotalTakes = totalTakes
            };
        }
    }
}
