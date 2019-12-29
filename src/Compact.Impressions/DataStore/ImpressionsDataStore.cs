using System.Collections.Generic;

namespace Compact.Impressions
{
    public interface IImpressionsDataStore
    {
        void Add(Impression impression);
    }

    public class ImpressionsDataStore : IImpressionsDataStore
    {
        private List<Impression> _impressions = new List<Impression>();

        public void Add(Impression impression)
        {
            _impressions.Add(impression);
        }
    }
}