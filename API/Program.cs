using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GAPI.DataStructure;
using GAPI.Grammar;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace API {

    public class Person {

        public int Age { get; set; }

        public string Name { get; set; }

    }

    public class Program {
        public static void Main (string[] args) {


             Func<string, string> translation = x =>
             {
                 return x.ToUpper();
             };

            Person p3 = new Person (){ Age=1    };
            Person p4 = p3;
            Person p5 = new Person() { Age = 1 };
            PropertyAndIndex grammar = new PropertyAndIndex ();
            Console.WriteLine (grammar[1]);

            int[] aa = new int[6] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine (aa.Length);
            for (int i = 0; i <= aa.Length - 1; i++) {
                Console.WriteLine (aa[i]);
            }

            for (int i = 0; i < aa.Length; i++) {
                Console.WriteLine (aa[i]);
            }

            Log.Logger = new LoggerConfiguration ()
                .MinimumLevel.Debug ()
                .MinimumLevel.Override ("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext ()
                .WriteTo.Console ()
                .WriteTo.File (Path.Combine ("logs", "api.txt"), rollingInterval : RollingInterval.Day)
                .CreateLogger ();

            ArrayList list = new ArrayList ();

            LinkedList<Person> a = new LinkedList<Person> ();
            Person p = new Person () { Age = 1, Name = "Gerald" };
            Person p1 = new Person () { Age = 1, Name = "Gerald" };
            a.AddFirst (p);
            bool ok = a.Contains (p);
            bool ok1 = a.Contains (p1);

            CreateHostBuilder (args).Build ().Run ();
        }

        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder => {
                webBuilder.UseStartup<Startup> ().UseSerilog ();
                webBuilder.ConfigureKestrel (options => options.ListenAnyIP (5000));
            });
    }
}