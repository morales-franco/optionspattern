using Microsoft.Extensions.Options;
using OptionsPattern.Entities;

namespace OptionsPattern.Services
{
    public class SingletonService: ISingletonService
    {
        private readonly AppConfiguration _configOptions;
        private readonly AppConfiguration _configMonitor;

        //private readonly AppConfiguration _configSnapshot;

        public SingletonService(IOptions<AppConfiguration> configOptions,
            IOptionsMonitor<AppConfiguration> configMonitor)
             /*
              * IOptionsSnapshot<AppConfiguration> configSnapshot - Excep
              */
        {
            _configOptions = configOptions.Value;
            _configMonitor = configMonitor.CurrentValue;
            //_configSnapshot = configSnapshot.Value;
        }
    }
}
