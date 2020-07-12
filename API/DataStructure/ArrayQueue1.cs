using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataStructure
{
    //对一次性队列进行优化，变成无限次使用队列
    public class ArrayQueue1<T>
    {
        private readonly T[] _items;
        private readonly int _size = 0;
        private int _head = 0;
        private int _tail = 0;

        public ArrayQueue1(int size) {
            _items = new T[size];
            _size = size;
        }

        public bool Enqueue(T item) {
            // 队列末尾没有空间了
            if (_tail == _size) {
                // 整个队列都满了
                if (_head == 0) return false;

                for (var i = _head; i < _tail; i++) {
                    _items[i-_head] = _items[i];
                }
                // 搬移完以后重新更新head和tail
                _tail -= _head;
                _head = 0;
            }

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