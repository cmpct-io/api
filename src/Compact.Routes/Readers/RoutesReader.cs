using System.Collections.Generic;

namespace Compact.Routes
{
    public interface IRoutesReader
    {
        IEnumerable<Route> Get();

        Route Get(string shortcut);
    }

    public class RoutesReader : IRoutesReader
    {
        private readonly IRoutesDataStore _dataStore;

        public RoutesReader(IRoutesDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public IEnumerable<Route> Get()
        {
            return _dataStore.Get();
        }

        public Route Get(string shortcut)
        {
            return _dataStore.Get(shortcut);
        }
    }
}