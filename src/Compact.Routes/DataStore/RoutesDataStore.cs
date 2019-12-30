using System;
using System.Collections.Generic;
using System.Linq;

namespace Compact.Routes
{
    public interface IRoutesDataStore
    {
        IEnumerable<Route> Get();

        Route Get(string shortcut);

        void Add(Route route);
    }

    public class RoutesDataStore : IRoutesDataStore
    {
        private List<Route> _routes = new List<Route>();

        public IEnumerable<Route> Get()
        {
            return _routes;
        }

        public Route Get(string routeId)
        {
            return _routes
                .FirstOrDefault(rou => routeId
                    .Equals(rou.Id, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Route route)
        {
            _routes.Add(route);
        }
    }
}