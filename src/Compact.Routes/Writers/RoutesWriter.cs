using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compact.Routes
{
    public interface IRoutesWriter
    {
        Task CreateAsync(string routeId, List<string> links);
    }

    public class RoutesWriter : IRoutesWriter
    {
        private readonly IRoutesDataStore _dataStore;

        public RoutesWriter(IRoutesDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task CreateAsync(string routeId, List<string> links)
        {
            var route = new Route
            {
                Id = routeId,
                Links = links
                    .Distinct()
                    .Select(lnk => new Link { Target = lnk })
            };

            await _dataStore.AddAsync(route);
        }
    }
}