using System.Threading.Tasks;

namespace Compact.Reports
{
    public interface IReportWriter
    {
        Task AddAsync(string routeId, string name, ReportType reportType);
    }

    public class ReportWriter : IReportWriter
    {
        private readonly IReportsDataStore _dataStore;

        public ReportWriter(IReportsDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task AddAsync(string routeId, string name, ReportType reportType)
        {
            await _dataStore.AddAsync(new Report
            {
                Id = "report1",
                RouteId = routeId,
                Name = name,
                ReportType = reportType
            });
        }
    }
}