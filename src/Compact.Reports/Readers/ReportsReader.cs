using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<IEnumerable<Report>> GetAsync(string routeId)
        {
            var results = await _dataStore.GetAsync(routeId);

            return results;
        }
    }
}
