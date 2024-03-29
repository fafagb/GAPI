using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using GAPI.API.Data;
using GAPI.DataStructure;
using GAPI.Grammars;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace API
{


    

    public class Program
    {












         public static long GetOpenTime(DateTime OpenTime)
        {
            TimeSpan ts = OpenTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalDays);
        }



         private static async Task ReceiveMessagesAsync(ClientWebSocket webSocket)
    {
        byte[] buffer = new byte[1024];
        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            }
            else
            {
              var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.Write(message);
            }
        }
    }

        public static async Task Main(string[] args)
        {

    Uri uri = new Uri("ws://localhost:7000/openai/ask?ask=为什么是北京&que=为什么是北京"); // Update with your URL
  //Uri uri = new Uri("ws://ai.myi.cn/ws/openai/ask?ask=写一份详细的语宙gpt的功能说明&"); // Update with your URL
        ClientWebSocket webSocket = null;

        try
        {
            webSocket = new ClientWebSocket();
            await webSocket.ConnectAsync(uri, CancellationToken.None);
            await ReceiveMessagesAsync(webSocket);
        }
        catch (Exception ex)
        {  await webSocket.ConnectAsync(uri, CancellationToken.None);
            // Handle the exception as per your needs
            Console.WriteLine($"Error: {ex.Message}");
          

        }
        finally
        {
            if (webSocket != null)
                webSocket.Dispose();
            Console.WriteLine("WebSocket closed.");
        }







Person person11=new Person();
person11.IsAlive=false;

  var opentime = GetOpenTime(Convert.ToDateTime("2023-04-10 16:43:10.882"));


var dic=new Dictionary<long,int>(){{123,2}};
                    var resul = dic.Where(t => t.Value > 0).Select(t => t.Key).ToArray();



 var results = dic.Where(t => t.Value > 0).Select(t => t.Key).ToArray();
            try
            {
                Console.Write("123");
            }
            catch (System.Exception)
            {
                
                throw;
            }finally{

 Console.Write("finally");
            }

 Log.Logger = new LoggerConfiguration()
                      .MinimumLevel.Debug()//最小等级
                      //  .MinimumLevel.Error()
                      .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                      .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                      .Enrich.FromLogContext()//需要加上，来自日志的上下文
                      .WriteTo.Console()//写到控制台，调式时比较直观
                      .WriteTo.File("Logs/logs.txt", rollOnFileSizeLimit: true, fileSizeLimitBytes: 1024 * 1024 * 2, retainedFileCountLimit: 60)
                       
                      .CreateLogger();

            var tech = Convert.ToInt32((19 / (20 * 1.0)) * 100);

            Test test = new Test();
            //test.Fibo(3);
            for (int i = 0; i < 2; i++)
            {
                Task.Run(() =>
                {
                    test.Testgo(1);

                });
                Console.WriteLine("主线程");
            }

            Person person = new Person();
            test.Test1(person);
            List<Person> ll = new List<Person>();
            test.Test2(ll);

            long[] llll = new long[] { 1 };
            var sssssss = llll.Take(2).ToArray();

            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            Console.WriteLine(s.Pop());

            GBStack<int> stack = new GBStack<int>(8);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            List<string> listAny1 = new List<string>();
            bool have = listAny1.Any();
            //List<string> listAny2=null;
            // listAny2.Any();

            #region 正则
            string line = @"\login\asdads";
            Regex reg = new Regex(@"\\(.*?)\\");
            Match match = reg.Match(line);
            string value = match.Groups[1].Value;
            Console.WriteLine("value的值为：{0}", value);
            #endregion

            #region Task回调
            TaskFactory taskFactory = new TaskFactory();
            List<Task> tastServiceList = new List<Task>();
            for (int i = 0; i < 3; i++)
            {
                tastServiceList.Add(Task.Run(() =>
                {

                    Console.WriteLine("123");
                    Thread.Sleep(3000);
                }).ContinueWith(t =>
                {

                    Console.WriteLine("456");
                }));
            }

            taskFactory.ContinueWhenAll(tastServiceList.ToArray(), t =>
            {
                Console.WriteLine("全部完成");
            });
            #endregion

            #region 转换

            // Dad  dad=new Dad();
            // Son son=dad;//需要强制转换
            Son son = new Son();
            Dad dad = son;

            List<int> li = new List<int>();
            IEnumerable<int> le1 = li;

            IEnumerable<int> le2 = new List<int>();
            //li=le2;//不行
            li = le2.ToList();
            //结论：子类可以赋值父类，反之则不行需要强制转换
            #endregion
            #region 迭代器
            Iterator iterator = new Iterator();
            // iterator.OddSequence (100, 1000).ToList();//在ToList的时候才调用了OddSequence方法。
            //List<int> li=  iterator.OddSequence (100, 1000).ToList();
            //   foreach (var item in li)
            //   {
            //       Console.WriteLine(item);
            //   }
            #endregion

            #region 本地方法
            Foo foo = new Foo();
            var flist = foo.Fibonacci(10).ToList();
            //foo.OddSequence (100, 1000);不用ToList()就报错了，这就是本地方法迭代器和普通方法迭代器的在异常上的区别
            List<int> list1 = foo.Bar<int>(new int[5] { 0, 1, 2, 3, 4 }).ToList();

            //本地方法
            // int Sim () {
            //     Console.WriteLine ("打印");
            //     return 1 + 1;
            // }

            //如果你的本地方法只一句代码,可以简化语法。

            int Sim() => 1 + 1;
            Func<int> ff = Sim;

            int cc = ff();
            #endregion

            #region 时间戳
            DateTimeUtil util = new DateTimeUtil();
            long l1 = util.ConvertToTimeStmap(Convert.ToDateTime("2020-09-29 13:21:25"));
            var dt1 = util.ConvertToDateTime(l1);
            var dt2 = util.TimeStampToDateTime(l1);
            DateTime timeStamp = new DateTime(1970, 1, 1);
            long l2 = timeStamp.Ticks;
            #endregion

            #region  委托   
            TestDelegate testDelegate = new TestDelegate();

            testDelegate.Use((x1, x2) => { return x1 - x2; });
            testDelegate.Use((x1, x2) => { x1 = 3; x2 = 1; return x1 - x2; });

            testDelegate.Use1((x, y) => { Console.WriteLine("回调"); return x(3) + y; });

            testDelegate.Use2((x) => { return gbF => { return 1; }; });
            testDelegate.Use3(x => { return true; });
            int u = testDelegate.Call(9, 4);

            testDelegate.UseTask(new Task(() =>
            {
                Console.WriteLine("启动了新线程");
            }));

            Console.WriteLine(u);

            Func<string, string> translation = x =>
            {
                return x.ToUpper();
            };

            GBDataBase gBDataBase = new GBDataBase();
            gBDataBase.Excute(1); //执行读操作
            gBDataBase.DelegateModeExcute(db => db.ExecuteRead()); //执行读操作

            MessageConfigure message = new MessageConfigure();
            message.Send(configure => configure.UseEmail());
            #endregion

            #region  引用类型
            Person p3 = new Person() { Age = 1 };
            Person p4 = p3; //p3,p4存储同一个内存地址
            Person p5 = new Person() { Age = 1 };
            #endregion

            #region 属性和索引器
            PropertyAndIndex grammar = new PropertyAndIndex();
            Console.WriteLine(grammar[1]);

            #endregion

            #region 最简单的循环
            int[] aa = new int[6] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(aa.Length);
            for (int i = 0; i <= aa.Length - 1; i++)
            {
                Console.WriteLine(aa[i]);
            }

            for (int i = 0; i < aa.Length; i++)
            {
                Console.WriteLine(aa[i]);
            }
            #endregion

            #region 动态数组（扩容数组）
            //缺点，添加元素为object类型，所以存数据和取数据就涉及到了装箱和拆箱的操作，性能低
            ArrayList list = new ArrayList();
            //List<T>  所以产生了泛型集合
            #endregion

            #region 链表
            //last,late,latest
            LinkedList<Person> a = new LinkedList<Person>();

            Person person1 = new Person() { Age = 1, Name = "Gerald1" };
            Person person2 = new Person() { Age = 2, Name = "Gerald2" };
            Person person3 = new Person() { Age = 3, Name = "Gerald3" };
            LinkedListNode<Person> lln1 = new LinkedListNode<Person>(person1);
            LinkedListNode<Person> lln2 = new LinkedListNode<Person>(person2);
            a.AddFirst(lln1); //头插法
            a.AddFirst(lln2); //头插法
            // a.AddLast(lln1);//尾插法
            // a.AddLast(lln1);//尾插法
            foreach (var item in a)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("结束");

            a.AddAfter(lln1, person3);
            foreach (var item in a)
            {
                Console.WriteLine(item.Name);
            }
            #endregion

            #region $语法
            Console.WriteLine(string.Format("{0}和{1}", "祖国", "人民"));
            string name1 = "祖国";
            string name2 = "人民";
            Console.WriteLine($"{name1}和{name2}");
            #endregion

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine("logs", "api.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) .ConfigureLogging((hostingContext, builder) =>
             {
            
                 //过滤掉系统默认的一些日志
                //  builder.AddFilter("System", LogLevel.Information);
                //  builder.AddFilter("Microsoft", LogLevel.Information);
                //  builder.AddConsole();
             })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                
                webBuilder.UseStartup<Startup>().UseSerilog();
                    webBuilder.ConfigureKestrel (options => options.ListenAnyIP (7000));
                webBuilder.ConfigureLogging(configure => configure.AddDebug());
                webBuilder.UseKestrel(opt =>
                {

                    opt.Limits.MinRequestBodyDataRate = null;
                });
            }).UseSerilog();
    }
}