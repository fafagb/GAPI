using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MySql.Data.MySqlClient;

namespace API.Data {
    public class SqlHelper {

//写一个异步方法，方法内容是获取时间戳
        public async Task<string> GetTimeStampAsync () {
            string sql = "select now()";
            var list = await GetAsync (sql);
            return list[0];
        }


        public static List<string> Get (string sql, params object[] parameters) {
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection ();
            connection.ConnectionString = "server=localhost;userid=root;pwd=wm360;port=3308;database=gb;sslmode=none;";
            connection.Open ();
            var cmd = connection.CreateCommand ();

            cmd.CommandText = sql;
            var reader = cmd.ExecuteReader ();
            List<string> list = new List<string> ();
            while (reader.Read ()) {
                int id = reader.GetInt32 (0);
                string name = reader.GetString (1);
                list.Add (name);

            }

            connection.Close ();
            connection.Dispose ();
            return list;
        }

        public async Task<List<string>> GetAsync (string sql, params object[] parameters) {
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection ();
            connection.ConnectionString = "server=localhost;userid=root;pwd=wm360;port=3308;database=gb;sslmode=none;";
             connection.ConnectionString = "server=localhost;userid=root;pwd=139891gb;port=3306;database=mydb;sslmode=none;";
            connection.Open ();
            var cmd = connection.CreateCommand ();

            cmd.CommandText = sql;
              cmd.Parameters.Add("@name",MySqlDbType.VarChar,1000,"");
               cmd.Parameters.AddWithValue("@name",parameters[0]);
            var reader = await cmd.ExecuteReaderAsync ();
            List<string> list = new List<string> ();
            while (reader.Read ()) {
                int id = reader.GetInt32 (0);
                string name = reader.GetString (1);
                list.Add (name);

            }

            connection.Close ();
            connection.Dispose ();

            return list;
        }

      

    }

}