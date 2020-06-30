using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace API
{

    public class Person
    {

        public int Age { get; set; }

        public string Name { get; set; }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug() //设置输出日志的最小级别
               .MinimumLevel.Override("Microsoft", LogEventLevel.Information) //命名空间以Microsoft开头的日志输出的最小级别设置为Information
               .Enrich.FromLogContext()
                .WriteTo.Console()
               .WriteTo.File(Path.Combine("logs", "api.txt"), rollingInterval: RollingInterval.Day)
               .CreateLogger();
            LinkedList<Person> a = new LinkedList<Person>();
            Person p = new Person() { Age = 1, Name = "Gerald" };
            Person p1 = new Person() { Age = 1, Name = "Gerald" };
            a.AddFirst(p);
            bool ok = a.Contains(p);
            bool ok1 = a.Contains(p1);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                    webBuilder.ConfigureKestrel(options => options.ListenAnyIP(5000));
                });
    }
}
