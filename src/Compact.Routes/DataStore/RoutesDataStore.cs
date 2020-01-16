using Compact.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private List<Route> _routes = new List<Route>();

        public RoutesDataStore(IAzureStorageManager fileStore)
        {
            _fileStore = fileStore;
        }

        public async Task<Route> GetAsync(string routeId)
        {
            var cachedResult = _routes
                .FirstOrDefault(rou => routeId
                    .Equals(rou.Id, StringComparison.OrdinalIgnoreCase));

            if (cachedResult != null)
            {
                return cachedResult;
            }

            var downloadedResult = await _fileStore.ReadObject<Route>("routes", $"{routeId}.json");

            return downloadedResult;
        }

        public async Task AddAsync(Route route)
        {
            // Permanent storage
            await _fileStore.StoreObject("routes", $"{route.Id}.json", route);

            // Cached storage
            //_routes.Add(route);
        }
    }
}