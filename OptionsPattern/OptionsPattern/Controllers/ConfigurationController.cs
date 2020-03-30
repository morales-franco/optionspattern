using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPattern.Entities;
using OptionsPattern.Services;

namespace OptionsPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly AppConfiguration _configOptions;
        private readonly AppConfiguration _configSnapshot;
        private readonly AppConfiguration _configMonitor;

        public ConfigurationController(IOptions<AppConfiguration> configOptions,
            IOptionsSnapshot<AppConfiguration> configSnapshot, 
            IOptionsMonitor<AppConfiguration> configMonitor,
            ISingletonService singletonService,
            ITransientService transientService)
        {
            /*
             * IOption<T>: Set values when la app starts and not update their values.
             * 
             * IOptionsSnapshot<T>: It is a Scoped service - update theirs values in each request, provides a snapshot of the options at the time
             * the IOptionsSnapshot<T> object is constructed (in each request). Options snapshots are designed for use with transient 
             * and scoped dependencies.
             * It is a scoped service for that reason, you can not inject it in a singleton service.
             *  
             * IOptionsMonitor<T>: It is a Singleton Service - retrieves current option values at any times. IOptionsSnapshot<T> only retrieve the values
             * one time per request.
             * It is especially useful in singleton dependencies.
             */
            _configOptions = configOptions.Value;
            _configSnapshot = configSnapshot.Value;
            _configMonitor = configMonitor.CurrentValue;

            /*
             * Monitor is a singleton service that monitoring the appSettings all the time.
             * We can listen the appSettings changes using Onchange callback.
             */
            configMonitor.OnChange(a =>
            {
                Console.WriteLine($"Section change! {a}");
            });
        }

        public IActionResult Get()
        {
            return Ok(new
            {
                Options = _configOptions.Email,
                Snapshot = _configSnapshot.Email,
                Monitor = _configMonitor.Email,
            });
        }

        


    }
}