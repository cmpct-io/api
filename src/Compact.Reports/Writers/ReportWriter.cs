namespace Compact.Reports
{
    public interface IReportWriter
    {
        void Add(string routeId, string name, ReportType reportType);
    }

    public class ReportWriter : IReportWriter
    {
        private readonly IReportsDataStore _dataStore;

        public ReportWriter(IReportsDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Add(string routeId, string name, ReportType reportType)
        {
            _dataStore.Add(new Report
            {
                Id = "report1",
                RouteId = routeId,
                Name = name,
                ReportType = reportType
            });
        }
    }
}