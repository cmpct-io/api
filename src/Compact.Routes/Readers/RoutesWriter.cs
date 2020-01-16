using System.Threading.Tasks;

namespace Compact.Routes
{
    public interface IRoutesWriter
    {
        Task CreateAsync(string routeId, string target, string password);
    }

    public class RoutesWriter : IRoutesWriter
    {
        private readonly IRoutesDataStore _dataStore;

        public RoutesWriter(IRoutesDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task CreateAsync(string routeId, string target, string password)
        {
            await _dataStore.AddAsync(new Route
            {
                Id = routeId,
                Target = target,
                Password = password
            });
        }
    }
}