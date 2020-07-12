using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataStructure
{
    //一次性队列
    public class ArrayQueue<T>
    {
        // 队列数组
        private readonly T[] _items;
        private readonly int _size = 0;
        private int _head = 0;
        private int _tail = 0;

        public ArrayQueue(int size) {
            _items = new T[size];
            _size = size;
        }

        public bool Enqueue(T item) {
            if (_tail == _size) return false;
            _items[_tail] = item;
            _tail++;
            return true;
        }


        public T Dequeue() {
            if (_head == _tail) return default;
            var ret = _items[_head];
            _head++;
            return ret;
        }
    }
}
