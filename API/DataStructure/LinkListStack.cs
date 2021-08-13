using System;
namespace GAPI.DataStructure {

    public class GBNode<T> {

        public T Data { get; set; }

        public GBNode<T> Next { get; set; }

        public GBNode (T data) {
            Data = data;
            Next = null;

        }

    }
    //链表栈:基于链表的栈
    public class LinkListStack {

        public bool Push () {

            return true;

        }

        public bool Pop () {

            return true;

        }

    }

}