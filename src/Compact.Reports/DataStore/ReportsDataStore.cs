using System.Collections.Generic;
using System.Linq;

namespace Compact.Reports
{
    public interface IReportsDataStore
    {
        IEnumerable<Report> Get(string routeId);

        void Add(Report report);
    }

    public class ReportsDataStore : IReportsDataStore
    {
        private List<Report> _reports = new List<Report>();

        public IEnumerable<Report> Get(string routeId)
        {
            return _reports.Where(rep => routeId.Equals(rep.RouteId, System.StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Report report)
        {
            _reports.Add(report);
        }
    }
}