using Compact.Infrastructure;
using System.Threading.Tasks;

namespace Compact.Routes
{
    public interface IRoutesDataStore
    {
        Task<Route> GetAsync(string routeId);

        Task AddAsync(Route route);
    }

    public class RoutesDataStore : IRoutesDataStore
    {
        private readonly IAzureStorageManager _fileStore;

        private const string CONTAINER_NAME = "routes";

        public RoutesDataStore(IAzureStorageManager fileStore)
        {
            _fileStore = fileStore;
        }

        public async Task<Route> GetAsync(string routeId)
        {
            var downloadedResult = await _fileStore.ReadObject<Route>(CONTAINER_NAME, $"{routeId}.json");

            return downloadedResult;
        }

        public async Task AddAsync(Route route)
        {
            // Permanent storage
            await _fileStore.StoreObject(CONTAINER_NAME, $"{route.Id}.json", route);
        }
    }
}