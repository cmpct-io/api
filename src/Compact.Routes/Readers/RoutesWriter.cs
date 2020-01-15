namespace Compact.Routes
{
    public interface IRoutesWriter
    {
        void Create(string id, string target, string password);
    }

    public class RoutesWriter : IRoutesWriter
    {
        private readonly IRoutesDataStore _dataStore;

        public RoutesWriter(IRoutesDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Create(string routeId, string target, string password)
        {
            _dataStore.Add(new Route
            {
                Id = routeId,
                Target = target,
                Password = password
            });
        }
    }
}