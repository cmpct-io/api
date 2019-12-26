namespace Compact.Routes
{
    public interface IRoutesWriter
    {
        void Create(string id, string target, string shortcut);
    }

    public class RoutesWriter : IRoutesWriter
    {
        private readonly IRoutesDataStore _dataStore;

        public RoutesWriter(IRoutesDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Create(string id, string target, string shortcut)
        {
            _dataStore.Add(new Route
            {
                Id = id,
                Target = target,
                Shortcut = shortcut
            });
        }
    }
}