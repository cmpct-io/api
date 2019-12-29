using System;

namespace Compact.Impressions
{
    public interface IImpressionsWriter
    {
        void Add(string routeId);
    }

    public class ImpressionsWriter : IImpressionsWriter
    {
        private readonly IImpressionsDataStore _dataStore;

        public ImpressionsWriter(IImpressionsDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Add(string routeId)
        {
            var impression = new Impression
            {
                Id = "impression1",
                RouteId = routeId,
                DateViewed = DateTime.UtcNow
            };

            _dataStore.Add(impression);
        }
    }
}