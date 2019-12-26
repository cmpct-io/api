using Compact.Api.Models.Enum;

namespace Compact.Api.Models.DomainModels
{
    public class Media
    {
        public string Id { get; set; }

        public MediaType Type { get; set; }

        public string MediaFilePath { get; set; }
    }
}