using System;
using System.Collections;
using System.Collections.Generic;

namespace GAPI.Grammar
{


 



    public class PropertyAndIndex
    {

        private int _id;
        public int ID
        {
            get { if (_id == 0) { return 1; } else { return _id; } }
            set
            {
                if (value == 0)
                    _id = 1;
                else
                    _id = value;
            }
        }

        private List<string> _list = new List<string>() { "1", "2", "3" }; //私用,不想在外部声明被使用
        public string this[int index]
        {

            get
            {
                return _list[index];
            }

        }





    }
}