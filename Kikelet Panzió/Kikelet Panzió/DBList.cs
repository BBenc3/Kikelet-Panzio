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
        internal string username { get; set; }
        internal string password { get; set; }
        public List<Object> list { get; }
        protected string database;
        protected string table;
        protected string conString;
        protected string insertString; //A children osztályok construktorában kell beállítani.

        private static readonly Dictionary<string, Type> tableTypes = new Dictionary<string, Type>
        {
            { "Room", typeof(Room) },
            { "RegisteredGuest", typeof(RegisteredGuest) },
            { "Reservation", typeof(Reservation) }
        };

        public DBList(string database, string username, string password) 
        {
            this.username = username;
            this.password = password;
            //Az inheritance miatt a table értéke a leszármazott osztály konstruktorában kerül beállításra
            this.database = database;
            list = new List<Object>();
            conString = $"Server=localhost;Database={database};Uid={username};Pwd={password};";
        }

        /// <summary>
        /// A kapott táblanév segítségével betölti az adatbázisból a megfelelő tábla adatait
        /// </summary>
        /// <param name="table"></param>
        public void LoadFromDB()
        {
            if (!tableTypes.ContainsKey(table))
            {
               throw new ArgumentException("Nem létező tábla");
            }
            Type type = tableTypes[table];
            list.Clear();

            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();
                string sqlCmd = $"SELECT * FROM {table}";
                using (MySqlCommand mSqlcmd = new MySqlCommand(sqlCmd, connection))
                using (MySqlDataReader rdr = mSqlcmd.ExecuteReader()) 
                {
                    while (rdr.Read())
                    {
                        //A megfelelő osztályból csinál egy példányt, amit a listához ad
                        list.Add(Activator.CreateInstance(type, rdr));
                    }
                }
            }
        }

        /// <summary>
        /// A kapott objektumot beszúrja az adatbázisba
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="ArgumentException"></exception>
        public void InsertToDB(Object obj)
        {
            if (!tableTypes.ContainsKey(table))
            {
                throw new ArgumentException("Nem létező tábla");
            }
            Type type = tableTypes[table];
            
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();
                string sqlCmd = insertString + $"({obj.ToString()})";
                using (MySqlCommand mSqlcmd = new MySqlCommand(sqlCmd, connection))
                {
                    mSqlcmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Az adatbázisból lekéri az utolsó rekordot
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void GetLastFroDB()
        {
            if (!tableTypes.ContainsKey(table))
            {
                throw new ArgumentException("Nem létező tábla");
            }
            Type type = tableTypes[table];
            list.Clear();

            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();
                string sqlCmd = $"SELECT * FROM {table} ORDER BY {table}Id DESC LIMIT 1";
                using (MySqlCommand mSqlcmd = new MySqlCommand(sqlCmd, connection))
                using (MySqlDataReader rdr = mSqlcmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(Activator.CreateInstance(type, rdr));
                    }
                }
            }
        }
    }

    internal class RoomList : DBList
    {
        public RoomList(string database, string username, string password) : base(database, username, password)
        {
            table = "Room";
            insertString = $"INSERT INTO Room (roomNumber, accommodation, price) VALUES";
        }
    }

    internal class RegisteredGuestList : DBList
    {
        public RegisteredGuestList(string database, string username, string password) : base(database, username, password)
        {
            table = "RegisteredGuest";
            insertString = $"INSERT INTO RegisteredGuest (guestCode, guestName, birthDay, country, postalCode, city, address, email, vip, banned) VALUES";
        }
    }

    internal class ReservationList : DBList
    {
        public ReservationList(string database, string username, string password) : base(database, username, password)
        {
            table = "Reservation";
            insertString = $"INSERT INTO Reservation (checkedIn, checkedOut, guestId, roomId, firstReservedDay, lastReservedDay, reservationStatus) VALUES";
        }
    }
}
