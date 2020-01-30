using Microsoft.Extensions.Configuration;

namespace Compact.Infrastructure
{
    public interface IConfigurationValueProvider
    {
        string GetValue(string key);
    }

    public class ConfigurationValueProvider : IConfigurationValueProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigurationValueProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetValue(string key) =>
            _configuration[key];
    }
}