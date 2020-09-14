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

    public class LinkListStack {


        public   bool   Push(){

return  true;

        }

    }

}