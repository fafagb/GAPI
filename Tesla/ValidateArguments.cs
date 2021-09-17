using System;
using System.Collections.Generic; 

namespace   Tesla {
 public class ValidateArguments {
        public int Validate (string[] args) {

            int returnValue = 0;

        if(args.Length==0) return returnValue;
if(args[0].ToLower()=="--help"&&args.Length<=2)
{
 return 1;
}
            Dictionary<string, string> dic = new Dictionary<string, string> ();
            for (int i = 0; i < args.Length; i++) {
                if (args[i].ToLower() == "--name") {
                    dic.Add ("--name", args[i + 1]);
                }
                if (args[i] == "--count") {
                    dic.Add ("--count", args[i + 1]);
                }
                if (args[i] == "--help") {
                    dic.Add ("--help", args[i + 1]);
                }
            }

            if (dic.ContainsKey ("--name")) {
                int itemLength = dic["--name"].Length;
                if (!(itemLength >= 3 && itemLength <= 10)) {
                    returnValue = -1;
                    return returnValue;
                }
            }
            int result;

            if (dic.ContainsKey ("--count")) {
                bool isInt = int.TryParse (dic["--count"], out result);
                if (!(result >= 10 && result <= 100)) {
                    returnValue = -1;
                    return returnValue;
                }
            }

            if (dic.ContainsKey ("--help")) {
                returnValue =1 ;
            }

            return returnValue;

            // Console.WriteLine("Sample debug output");
            throw new System.ArgumentException ("Not yet implemented");
        }
    }

    }