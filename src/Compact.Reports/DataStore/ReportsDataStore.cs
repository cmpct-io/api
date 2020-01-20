using Compact.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compact.Reports
{
    public interface IReportsDataStore
    {
        Task<IEnumerable<Report>> GetAsync(string routeId);

        Task AddAsync(Report report);
    }

    public class ReportsDataStore : IReportsDataStore
    {
        private const string CONTAINER_NAME = "reports";

        private readonly IAzureStorageManager _storageManager;

        private Dictionary<string, IEnumerable<Report>> _cachedReports { get; set; }

        public ReportsDataStore(IAzureStorageManager storageManager)
        {
            _storageManager = storageManager;
            _cachedReports = new Dictionary<string, IEnumerable<Report>>();
        }

        public async Task<IEnumerable<Report>> GetAsync(string routeId)
        {
            if (!_cachedReports.Keys.Any(x => routeId.Equals(x, System.StringComparison.OrdinalIgnoreCase)))
            {
                var result = await _storageManager.ReadObject<List<Report>>(CONTAINER_NAME, $"{routeId}.json");

                _cachedReports.Add(routeId, result);

                return result;
            }

            return _cachedReports.GetValueOrDefault(routeId);
        }

        public async Task AddAsync(Report report)
        {
            _cachedReports.Remove(report.RouteId);

            var fileName = $"{report.RouteId}.json";
            var existingFile = await _storageManager.ReadObject<List<Report>>(CONTAINER_NAME, fileName);

            if (existingFile == null)
            {
                await _storageManager.StoreObject(
                    CONTAINER_NAME,
                    fileName,
                    new List<Report> { report });
            }
            else
            {
                existingFile.Add(report);

                await _storageManager.StoreObject(CONTAINER_NAME, fileName, existingFile);
            }
        }
    }
}