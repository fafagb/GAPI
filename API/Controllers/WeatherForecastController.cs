using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class WeatherForecastController : ControllerBase {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;
        private static readonly string[] Summaries = new [] {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController (ILogger<WeatherForecastController> logger, IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
             _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            _logger.LogInformation(contentRootPath);
            return await Task.Run (() => {
              
                return PhysicalFile(contentRootPath+@"/Resource/lxy1.gif", "image/gif");
               // return Ok ("胖头鱼陆新元");
            });

        }
    }
}