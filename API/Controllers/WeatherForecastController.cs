using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using GAPI.API.Data;
using GAPI.Grammars;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers {
    [ApiController]
    [Route ("[controller]/[action]")]
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
        public async Task<IActionResult> Get (string id) {

            string contentRootPath = _hostingEnvironment.ContentRootPath;
 _logger.LogInformation (contentRootPath);
          //  List<string> list = SqlHelper.Get ("select *  from    test where id=" + id);
           
            // string str = string.Empty;
            // foreach (var item in list) {
            //     str += item + ",";
            // }
              await TestThread ();
            return await Task.Run (() => {

                // return PhysicalFile(contentRootPath+@"/Resource/lxy1.gif", "image/gif");
                return Ok ("123");
            });
          
        }

        private async Task<int> TestThread () {
            await Test1 ();
            return 1;
        }

        private Task<int> Test1 () {
            return Task.Run (() => {
                Thread.Sleep (5000);
                return 1;
            });

        }

        [HttpGet]
        public async Task<IActionResult> GetPara (List<int> list) {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            _logger.LogInformation (contentRootPath);
            return await Task.Run (() => {

                // return PhysicalFile(contentRootPath+@"/Resource/lxy1.gif", "image/gif");
                return Ok ("胖头鱼陆新元");
            });

        }

    }
}