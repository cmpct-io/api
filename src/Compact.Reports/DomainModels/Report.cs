namespace Compact.Reports
{
    public class Report
    {
        public string Id { get; set; }

        public string RouteId { get; set; }

        public string Name { get; set; }

        public ReportType ReportType { get; set; }
    }
}