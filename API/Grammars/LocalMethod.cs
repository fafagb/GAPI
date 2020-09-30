using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GAPI.Grammars {

    public class Foo {
        public IEnumerable<T> Bar<T> (params T[] items) {
            if (items == null) throw new ArgumentException (nameof (items));

            IEnumerable<T2> Enumerate<T2> (T2[] array) //使用泛型及特性参数
            {
                //本地方法逻辑
                foreach (var item in array) {
                    yield return item; //使用迭代器
                }
            }

            return Enumerate<T> (items); //调用本地方法
            //return this.Enumerate<T>(items);  //调用成员方法
        }

        //    IEnumerable<T2> Enumerate<T2>([CallerMemberName] T2[] array)
        //      {

        //         //成员方法逻辑
        //           return  null;
        //      }

        public  IEnumerable<int> OddSequence (int start, int end) {
            if (start < 0 || start > 99)
                throw new ArgumentOutOfRangeException ("start must be between 0 and 99.");
            if (end > 100)
                throw new ArgumentOutOfRangeException ("end must be less than or equal to 100."); //Line 22
            if (start >= end)
                throw new ArgumentException ("start must be less than end.");

            return GetOddSequenceEnumerator ();

            IEnumerable<int> GetOddSequenceEnumerator () {
                for (int i = start; i <= end; i++) {
                    if (i % 2 == 1)
                        yield return i;
                }
            }
        }

    }

}