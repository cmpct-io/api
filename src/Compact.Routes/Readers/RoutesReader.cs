using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compact.Routes
{
    public interface IRoutesReader
    {
        Task<Route> GetAsync(string shortcut);
    }

    public class RoutesReader : IRoutesReader
    {
        private readonly IRoutesDataStore _dataStore;

        public RoutesReader(IRoutesDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<Route> GetAsync(string shortcut)
        {
            return await _dataStore.GetAsync(shortcut);
        }
    }
}