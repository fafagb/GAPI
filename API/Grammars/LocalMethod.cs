using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GAPI.Grammars {
    // 在 C# 中，大多数方法都是通过 return 语句立即把程序的控制权交回给调用者，同时也会把方法内的本地资源释放掉。而包含 yield 语句的方法则允许在依次返回多个值给调用者的期间保留本地资源，等所有值都返回结束时再释放掉本来资源，这些返回的值形成一组序列被调用者使用。在 C# 中，这种包含 yield 语句的方法、属性或索引器就是迭代器。
    // 迭代器中的 yield 语句分为两种：
    // yeild return，把程序控制权交回调用者并保留本地状态，调用者拿到返回的值继续往后执行。
    // yeild break，用于告诉程序当前序列已经结束，相当于正常代码块的 return 语句（迭代器中直接使用 return 是非法的）。
    public class Foo {

    public    IEnumerable<int> Fibonacci (int count) {
            int prev = 1;
            int curr = 1;
            for (int i = 0; i < count; i++) {
                yield return prev;
                int temp = prev + curr;
                prev = curr;
                curr = temp;
            }
        }

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

        public IEnumerable<int> OddSequence (int start, int end) {
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