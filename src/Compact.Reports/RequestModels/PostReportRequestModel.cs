namespace Compact.Reports
{
    public class PostReportRequestModel
    {
        public string RouteId { get; set; }

        public string Name { get; set; }

        public ReportType ReportType { get; set; }
    }
}