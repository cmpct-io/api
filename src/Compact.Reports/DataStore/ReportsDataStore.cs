using System.Collections.Generic;

namespace Compact.Reports
{
    public interface IReportsDataStore
    {
        void Add(Report report);
    }

    public class ReportsDataStore : IReportsDataStore
    {
        private List<Report> _reports = new List<Report>();

        public void Add(Report report)
        {
            _reports.Add(report);
        }
    }
}