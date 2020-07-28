using System;
using System.Collections;

namespace GAPI.DataStructure {

    public class Node<T> {

        public Node<T> Next;

        public T Data;

        public Node (T Data) {
            this.Data = Data;
            this.Next = null;
        }

    }

    public class LinkList<T> {

    }

}