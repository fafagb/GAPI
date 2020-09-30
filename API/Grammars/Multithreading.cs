using System;

namespace GAPI.Grammars {

    public class Multithreading {

        public void Test () {

            Action<string> action = x => { string ss = "gb" + x; };
            action.BeginInvoke ("name", null, null);
        }

    }

}