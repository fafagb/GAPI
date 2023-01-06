using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using GAPI.Grammars;
using Serilog;

namespace GAPI.API.Data
{
    public class Test
    {

        public int id { get; set; }
        public string name { get; set; }
        public int sex { get; set; }
        int i = 0;
        public void Testgo(int c)
        {
            Thread.Sleep(3000);
          
Log.Error("线程id"+Thread.CurrentThread.ManagedThreadId + "=====" + i);
            if (true) i++;

            if (i < 2)
            {
                Testgo(1);
            }

        }

        [Display(Name=nameof(Fibo))]
        public int Fibo(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            else
                return Fibo(n - 2) + Fibo(n - 1);
        }


        public void Test1(Person person)
        {
            person.Age = 1;

        }
        public int Test2(List<Person> list)
        {
            list.Add(new Person() { Age = 2 });

            return 1;

        }
    }
}