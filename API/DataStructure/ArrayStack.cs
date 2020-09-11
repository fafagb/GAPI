using System;
using System.Collections.Generic;
namespace GAPI.DataStructure {



    public class GBStack<T> {

        private int Count { get; set; }

        public  int  Size{get;set;}

        private T[] Array { get; set; }

        public GBStack (int size) {

            Size = size;
            Array = new T[Size];
        }

        public bool Push (T data) {
            if (Array.Length == Count) return false;
            Array[Count] = data;
            Count++;
            return true;
        }

        //出栈
        public T Pop () {
            if (Count == 0) return default;
            T data =Array[Count-1];
            Count--;
            return  data;
        }

    }

}