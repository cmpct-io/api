namespace Compact.Routes
{
    public interface IRoutesWriter
    {
        void Create(string id, string target);
    }

    public class RoutesWriter : IRoutesWriter
    {
        private readonly IRoutesDataStore _dataStore;

        public RoutesWriter(IRoutesDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Create(string routeId, string target)
        {
            _dataStore.Add(new Route
            {
                Id = routeId,
                Target = target
            });
        }
    }
}