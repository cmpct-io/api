using System.Collections.Generic;

namespace Compact.Api.Models.ResponseModels
{
    public class LineChartResponse
    {
        public IEnumerable<string> Labels { get; set; }

        public IEnumerable<DataSet> DataSets { get; set; }
    }

    public class DataSet
    {
        public string Label { get; set; }

        public int[] DataPoints { get; set; }
    }
}