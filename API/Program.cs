using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(options => options.ListenAnyIP(5000));
                });
    }
}
