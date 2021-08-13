using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Data {
    public  class SqlHelper {
        public static List<string> Get (string sql, params object[] parameters) {
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection ();
            connection.ConnectionString="server=localhost;userid=root;pwd=wm360;port=3308;database=gb;sslmode=none;";
            connection.Open ();
            var cmd = connection.CreateCommand ();

            cmd.CommandText = sql;
            var reader = cmd.ExecuteReader ();
            List<string> list = new List<string> ();
            while (reader.Read ()) 
            {
                int id = reader.GetInt32 (0);
                string name = reader.GetString (1);
                list.Add (name);

            }

            connection.Close();
            connection.Dispose();
            return list;
        }

    }

}