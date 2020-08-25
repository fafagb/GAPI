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

        public Node<T> _head;
        // 尾结点
        private Node<T> _last;

        // 当前链表节点个数
        public int Count { get; private set; }
        public void Add (T t) {
            Node<T> newNode = new Node<T> (t);
            if (_head == null) {

                _head = newNode;
                _last = newNode;
            } else {

                _last.Next = newNode;
                _last = newNode;
            }
            Count++;

        }
        /// <summary>
        /// 根据索引获取节点
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        private Node<T> GetNodeByIndex (int index) {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException ("index", "索引超出范围");

            var currentNode = _head;

            for (var i = 0; i < index; i++) {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this [int index] {
            get { return GetNodeByIndex (index).Data; }
            set { GetNodeByIndex (index).Data = value; }
            //get => GetNodeByIndex(index).Data;
            //set => GetNodeByIndex(index).Data = value;
        }

    }

}