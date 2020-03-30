using Microsoft.Extensions.Options;
using OptionsPattern.Entities;

namespace OptionsPattern.Services
{
    public class TransientService: ITransientService
    {
        private readonly AppConfiguration _configOptions;
        private readonly AppConfiguration _configSnapshot;
        private readonly AppConfiguration _configMonitor;

        public TransientService(IOptions<AppConfiguration> configOptions,
            IOptionsSnapshot<AppConfiguration> configSnapshot,
            IOptionsMonitor<AppConfiguration> configMonitor)
        {
            _configOptions = configOptions.Value;
            _configSnapshot = configSnapshot.Value;
            _configMonitor = configMonitor.CurrentValue;
        }
    }
}
