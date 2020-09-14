using System;
namespace GAPI.Grammars {

    public class GBDataBase {

        private GBDataBase CreateConn () {

            Console.WriteLine ("连接创建成功");
            return this;
        }

        private GBDataBase CreateCommand () {

            Console.WriteLine ("命令创建成功");
            return this;
        }

        internal GBDataBase ExecuteRead () {

            Console.WriteLine ("进行读操作");
            return this;
        }

        internal GBDataBase ExecuteWrite () {

            Console.WriteLine ("进行写操作");
            return this;
        }

        public void Excute (int flag) {

            var db = CreateConn ();

            db = db.CreateCommand ();

            switch (flag) {
                case 1:
                    db.ExecuteRead ();
                    break;
                case 2:
                    db.ExecuteWrite ();
                    break;
                default:
                    Console.WriteLine ("参数错误");
                    break;
            }





        }


//      public  void   AAA(GBDataBase db){
// db.ExecuteRead();
//      }


public void  DelegateModeExcute (Action<GBDataBase> func) {

 var db = CreateConn ();

            db = db.CreateCommand ();

          func(db);

}







    }


}