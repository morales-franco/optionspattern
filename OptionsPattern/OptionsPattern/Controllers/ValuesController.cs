using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPattern.Entities;

namespace OptionsPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppConfiguration _configOptions;

        public ValuesController(IOptions<AppConfiguration> configOptions)
        {
            _configOptions = configOptions.Value;
        }

        public IActionResult Get()
        {
            return Ok(new
            {
                Options = _configOptions.Email
            });
        }
    }
}