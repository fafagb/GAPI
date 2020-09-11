using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace GAPI.Grammars {
    public delegate int GBDelegate (int number);

    public delegate TResult GBFunc<in T1, in T2, out TResult> (T1 arg1, T2 arg2);




      public delegate TResult GBFun<in T, out TResult> (T arg);







    public class TestDelegate {
        public int Sum (int number) {
            return number + 5;
        }

        public int Sub (int arg1, int arg2) {

            return arg1 - arg2;
        }

        public  int Multiplication(GBDelegate gBDelegate,int x){

return 0;
        }



        public void Call () {
            // 原始
            // GBDelegate gBDelegate = new GBDelegate (Sum); //GBDelegate  gBDelegate=Sum;
            // gBDelegate (5);

            //匿名方法
            // GBDelegate gBDelegate = delegate (int x) { return x + 5; };
            // gBDelegate (5);

            //lambda
            // GBDelegate gBDelegate=x=>{return x+5;};
            // gBDelegate(5);

            //原始
            // GBFunc<int, int, int> gBFunc = new GBFunc<int, int, int> (Sub); //GBFunc<int,int,int> gBFunc =Sub;
            // gBFunc(5,1);

            //匿名方法
            //GBFunc<int, int, int> gBFunc=delegate(int arg1,int arg2){return arg1-arg2;};
            //gBFunc(5,1);

            //lambda
            // GBFunc<int, int, int> gBFunc=(x1,x2)=>{return x1-x2;};
            // gBFunc(5,1);

        
        //委托套委托
        GBFunc<GBDelegate,int,int> gBFunc=Multiplication;
        
        }

        public int Call (int x, int y) {

          return  Use ((x1, x2) => { x1 = x; x2 = y; return x1 - x2; });
        }

        //委托作为参数
        public int Use (GBFunc<int, int, int> gBFunc) {
           
         return   gBFunc (default, default);
        }

        public   void   Use1(GBFunc<GBDelegate,int,int> gBFunc){

Console.WriteLine("Use1");

        }

public  void   Use2(GBFun<GBDelegate,GBDelegate> gBFun){


}




    }

}