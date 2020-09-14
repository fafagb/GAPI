using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GAPI.Grammars {

     public  class Foo
  {
      public IEnumerable<T> Bar<T>(params T[] items)
      {
          if (items == null) throw new ArgumentException(nameof(items));
  
          IEnumerable<T2> Enumerate<T2> ( T2[] array) //使用泛型及特性参数
          {
              //本地方法逻辑
             foreach (var item in array)
            {
                 yield return item; //使用迭代器
             }
         }
 
         return Enumerate<T>(items); //调用本地方法
         //return this.Enumerate<T>(items);  //调用成员方法
     }
 
//    IEnumerable<T2> Enumerate<T2>([CallerMemberName] T2[] array)
//      {

       
//         //成员方法逻辑
//           return  null;
//      }
 }

}