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
        public async Task<string> TestDocker () {
            return "TestDocker";
        }

        [HttpGet]
        public async Task<IActionResult> Get (string id) {

            TestDelegate testDelegate = new TestDelegate ();
            Console.WriteLine ("await前" + Thread.CurrentThread.ManagedThreadId);
            await testDelegate.TestInvoke ();
            Console.WriteLine ("await后" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine ("进入");
            await AsyncFunction ();

            //             string contentRootPath = _hostingEnvironment.ContentRootPath;
            //  _logger.LogInformation (contentRootPath);
            //           //  List<string> list = SqlHelper.Get ("select *  from    test where id=" + id);

            //             // string str = string.Empty;
            //             // foreach (var item in list) {
            //             //     str += item + ",";
            //             // }
            //               await TestThread ();
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

        async Task<int> AsyncFunction () {

            await Task.Run (() => {
                Thread.Sleep (5000);

            });
            Console.WriteLine ("ok");
            // Console.WriteLine ("使用System.Threading.Tasks.Task执行异步操作.");
            // for (int i = 0; i < 10; i++) {
            //     Console.WriteLine (string.Format ("AsyncFunction:i={0}", i));
            // }
            return 1;
        }

        public async Task<ActionResult> Index () {
            DateTime startTime = DateTime.Now; //进入DoSomething方法前的时间
            var startThreadId = Thread.CurrentThread.ManagedThreadId; //进入DoSomething方法前的线程ID

            await DoSomething (); //耗时操作

            DateTime endTime = DateTime.Now; //完成DoSomething方法的时间
            var endThreadId = Thread.CurrentThread.ManagedThreadId; //完成DoSomething方法后的线程ID
            return Content ($"startTime:{ startTime.ToString("yyyy-MM-dd HH:mm:ss:fff") } startThreadId:{ startThreadId }<br/>endTime:{ endTime.ToString("yyyy-MM-dd HH:mm:ss:fff") } endThreadId:{ endThreadId }<br/><br/>");
        }

        /// <summary>
        /// 耗时操作
        /// </summary>
        /// <returns></returns>
        private async Task DoSomething () {
            await Task.Run (() => Thread.Sleep (10000));
        }

        public ActionResult Index1 () {
            DateTime startTime = DateTime.Now; //进入DoSomething方法前的时间
            var startThreadId = Thread.CurrentThread.ManagedThreadId; //进入DoSomething方法前的线程ID

            DoSomething1 (); //耗时操作

            DateTime endTime = DateTime.Now; //完成DoSomething方法的时间
            var endThreadId = Thread.CurrentThread.ManagedThreadId; //完成DoSomething方法后的线程ID
            return Content ($"startTime:{ startTime.ToString("yyyy-MM-dd HH:mm:ss:fff") } startThreadId:{ startThreadId }<br/>endTime:{ endTime.ToString("yyyy-MM-dd HH:mm:ss:fff") } endThreadId:{ endThreadId }<br/><br/>");
        }

        /// <summary>
        /// 耗时操作
        /// </summary>
        /// <returns></returns>
        private void DoSomething1 () {
            Thread.Sleep (10000);
        }

        public async Task<string> GetDataAsync2 () {
            var result = await System.IO.File.ReadAllBytesAsync (@"D:\睿易\Desktop.rar");
            Thread.Sleep (5000);
            return "ok";
        }

        [HttpGet]
        public async Task Test () {

            // GetString (1);
            // List<Task<string>> list = new List<Task<string>> ();
            // for (int i = 0; i < 5; i++) {
            //     list.Add (GetString (i));
            // }

            GetDataAsync2 ();
            List<Task<string>> list = new List<Task<string>> ();
            for (int i = 0; i < 5; i++) {
                list.Add (GetDataAsync2 ());
            }

        }

        [HttpGet]
        public async Task Test6 () {
            await GetDataAsync2 ();
        }

        public async Task<string> GetString (int i) {

            Thread.Sleep (5000);
            await Task.CompletedTask;
            return i.ToString ();
        }

    }
}