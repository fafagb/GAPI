using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using GAPI.DataStructure;
using GAPI.Grammars;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace API {

    public class Program {

        public static void Main (string[] args) {
Console.WriteLine("123");
            #region 正则
            string line = @"\login\asdads";
            Regex reg = new Regex (@"\\(.*?)\\");
            Match match = reg.Match (line);
            string value = match.Groups[1].Value;
            Console.WriteLine ("value的值为：{0}", value);
            #endregion

            #region Task回调
            TaskFactory taskFactory = new TaskFactory ();
            List<Task> tastServiceList = new List<Task> ();
            for (int i = 0; i < 3; i++) {
                tastServiceList.Add (Task.Run (() => {

                    Console.WriteLine ("123");
                    Thread.Sleep (3000);
                }).ContinueWith (t => {

                    Console.WriteLine ("456");
                }));
            }

            taskFactory.ContinueWhenAll (tastServiceList.ToArray (), t => {
                Console.WriteLine ("全部完成");
            });
            #endregion

            #region 转换

            // Dad  dad=new Dad();
            // Son son=dad;//需要强制转换
            Son son = new Son ();
            Dad dad = son;

            List<int> li = new List<int> ();
            IEnumerable<int> le1 = li;

            IEnumerable<int> le2 = new List<int> ();
            //li=le2;//不行
            li = le2.ToList ();
            //结论：子类可以赋值父类，反之则不行需要强制转换
            #endregion
            #region 迭代器
            Iterator iterator = new Iterator ();
            // iterator.OddSequence (100, 1000).ToList();//在ToList的时候才调用了OddSequence方法。
            //List<int> li=  iterator.OddSequence (100, 1000).ToList();
            //   foreach (var item in li)
            //   {
            //       Console.WriteLine(item);
            //   }
            #endregion

            #region 本地方法
            Foo foo = new Foo ();
            var flist = foo.Fibonacci (10).ToList ();
            //foo.OddSequence (100, 1000);不用ToList()就报错了，这就是本地方法迭代器和普通方法迭代器的在异常上的区别
            List<int> list1 = foo.Bar<int> (new int[5] { 0, 1, 2, 3, 4 }).ToList ();

            //本地方法
            // int Sim () {
            //     Console.WriteLine ("打印");
            //     return 1 + 1;
            // }

            //如果你的本地方法只一句代码,可以简化语法。

            int Sim () => 1 + 1;
            Func<int> ff = Sim;

            int cc = ff ();
            #endregion

            #region 时间戳
            DateTimeUtil util = new DateTimeUtil ();
            long l1 = util.ConvertToTimeStmap (Convert.ToDateTime ("2020-09-29 13:21:25"));
            var dt1 = util.ConvertToDateTime (l1);
            var dt2 = util.TimeStampToDateTime (l1);
            DateTime timeStamp = new DateTime (1970, 1, 1);
            long l2 = timeStamp.Ticks;
            #endregion

            #region  委托   
            TestDelegate testDelegate = new TestDelegate ();
            testDelegate.Use ((x1, x2) => { return x1 - x2; });
            testDelegate.Use ((x1, x2) => { x1 = 3; x2 = 1; return x1 - x2; });

            testDelegate.Use1 ((x, y) => { Console.WriteLine ("回调"); return x (3) + y; });

            testDelegate.Use2 ((x) => { return gbF => { return 1; }; });

            int u = testDelegate.Call (9, 4);

            Console.WriteLine (u);

            Func<string, string> translation = x => {
                return x.ToUpper ();
            };

            GBDataBase gBDataBase = new GBDataBase ();
            gBDataBase.Excute (1); //执行读操作
            gBDataBase.DelegateModeExcute (db => db.ExecuteRead ()); //执行读操作

            MessageConfigure message = new MessageConfigure ();
            message.Send (configure => configure.UseEmail ());
            #endregion

            #region  引用类型
            Person p3 = new Person () { Age = 1 };
            Person p4 = p3; //p3,p4存储同一个内存地址
            Person p5 = new Person () { Age = 1 };
            #endregion

            #region 属性和索引器
            PropertyAndIndex grammar = new PropertyAndIndex ();
            Console.WriteLine (grammar[1]);

            #endregion

            #region 最简单的循环
            int[] aa = new int[6] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine (aa.Length);
            for (int i = 0; i <= aa.Length - 1; i++) {
                Console.WriteLine (aa[i]);
            }

            for (int i = 0; i < aa.Length; i++) {
                Console.WriteLine (aa[i]);
            }
            #endregion

            #region 动态数组（扩容数组）
            //缺点，添加元素为object类型，所以存数据和取数据就涉及到了装箱和拆箱的操作，性能低
            ArrayList list = new ArrayList ();
            //List<T>  所以产生了泛型集合
            #endregion

            #region 链表
            LinkedList<Person> a = new LinkedList<Person> ();
            Person p = new Person () { Age = 1, Name = "Gerald" };
            a.AddFirst (p);
            #endregion

            #region $语法
            Console.WriteLine (string.Format ("{0}和{1}", "祖国", "人民"));
            string name1 = "祖国";
            string name2 = "人民";
            Console.WriteLine ($"{name1}和{name2}");
            #endregion

            Log.Logger = new LoggerConfiguration ()
                .MinimumLevel.Debug ()
                .MinimumLevel.Override ("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext ()
                .WriteTo.Console ()
                .WriteTo.File (Path.Combine ("logs", "api.txt"), rollingInterval : RollingInterval.Day)
                .CreateLogger ();
            CreateHostBuilder (args).Build ().Run ();
        }

        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder => {
                webBuilder.UseStartup<Startup> ().UseSerilog ();
                // webBuilder.ConfigureKestrel (options => options.ListenAnyIP (5000));
                webBuilder.ConfigureLogging (configure => configure.AddDebug ());
            });
    }
}