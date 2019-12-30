using System;
using System.Collections.Generic;
using System.Text;

namespace Compact.Reports
{
    public interface IReportsReader
    {
        IEnumerable<Report> Get(string routeId);
    }

    public class ReportsReader : IReportsReader
    {
        private readonly IReportsDataStore _dataStore;

        public ReportsReader(IReportsDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public IEnumerable<Report> Get(string routeId)
        {
            var results = _dataStore.Get(routeId);

            return results;
        }
    }
}
