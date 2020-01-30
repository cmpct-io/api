using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compact.Reports
{
    public interface IReportsReader
    {
        Task<IEnumerable<Report>> GetAsync(string routeId);
    }

    public class ReportsReader : IReportsReader
    {
        private readonly IReportsDataStore _dataStore;

        public ReportsReader(IReportsDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<Report>> GetAsync(string routeId) =>
            await _dataStore.GetAsync(routeId);
    }
}