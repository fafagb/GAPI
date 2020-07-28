using System;
using System.Collections;

namespace GAPI.DataStructure {
    //实现一个一次性队列   author by  fafagb

    public class ThrowawayArrayQueue<T> {
        public T[] ArrayQueue { get; set; }
        public int _size { get; set; }

        public int _Count { get; set; }

        public ThrowawayArrayQueue (int size) {
            _size = size;
            _Count = size;
        }

        public bool Enqueue (T element) {
            if (_Count == 0) return false;
            ArrayQueue[_Count] = element;
            _Count--;
            return true;
        }

        public T Dequeue () {
            if (_Count == 0) return default;

            return ArrayQueue[_Count];

        }

    }
}