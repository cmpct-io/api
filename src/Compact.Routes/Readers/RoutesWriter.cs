using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compact.Routes
{
    public interface IRoutesWriter
    {
        Task CreateAsync(string routeId, List<string> links, string password);
    }

    public class RoutesWriter : IRoutesWriter
    {
        private readonly IRoutesDataStore _dataStore;

        public RoutesWriter(IRoutesDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task CreateAsync(string routeId, List<string> links, string password)
        {
            var route = new Route
            {
                Id = routeId,
                Links = links.Select(lnk => new Link { Target = lnk }),
                Password = password
            };

            await _dataStore.AddAsync(route);
        }
    }
}