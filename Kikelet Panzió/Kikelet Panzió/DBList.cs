using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Data.SqlClient;
using MySqlConnector;

namespace Kikelet_Panzió
{
    internal class DBList
    {
        string username { get; set; }
        string password { get; set; }
        List<Object> list { get; set; }

        public void LoadFromDB(string table)
        {
            list.Clear();
            MySqlConnection connection = new MySqlConnection($"server=localhost;user={username};password={password};database=kikeletpanzio");
            connection.Open();
            string sql = $"SELECT * FROM {table}";
            MySqlCommand mSqlcmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = mSqlcmd.ExecuteReader();
            while (rdr.Read())
            {
                //Fogalmam sincs hogy kell megcsinálni (egy új példány kéne de dinamikusan változzon melyik osztály példányát deklarálom)
                list.Add(new Telepules(rdr[0].ToString(), (int)rdr[1]));
            }
            rdr.Close();
            connection.Close();
        }
    }
}
