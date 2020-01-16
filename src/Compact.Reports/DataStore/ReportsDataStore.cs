using Compact.Infrastructure;
using System.Collections.Generic;
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
        private readonly IAzureStorageManager _storageManager;

        private const string CONTAINER_NAME = "reports";

        public ReportsDataStore(IAzureStorageManager storageManager)
        {
            _storageManager = storageManager;
        }

        public async Task<IEnumerable<Report>> GetAsync(string routeId)
            => await _storageManager.ReadObject<List<Report>>(CONTAINER_NAME, $"{routeId}.json");

        public async Task AddAsync(Report report)
        {
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