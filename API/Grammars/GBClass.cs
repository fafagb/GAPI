using System;
using System.Collections.Generic;

namespace GAPI.Grammars {

    public class Dad {

    }

    public class Son : Dad {

    }

    public class Person {


public  bool  IsAlive { get; set; }=true;
public  bool IsOk { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        private string[] answers;

        public string[] Answers {
            get { 
                return answers; }
            set {
                if (value == null) { 
                    answers = new string[0]; } else {

                    answers = value;
                }
            }
        }
    }

}