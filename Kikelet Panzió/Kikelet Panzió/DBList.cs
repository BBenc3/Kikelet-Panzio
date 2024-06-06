using MySqlConnector;
using System.Collections.ObjectModel;
using System.Windows;

namespace Kikelet_Panzió
{
    internal class DBList
    {
        public ObservableCollection<object> list { get; }
        internal string username { get; set; }
        internal string password { get; set; }
        protected string database;
        protected string table;
        protected string conString;

        private static readonly Dictionary<string, Type> tableTypes = new Dictionary<string, Type>
        {
            { "room", typeof(Room) },
            { "RegisteredGuest", typeof(RegisteredGuest) },
            { "reservation", typeof(Reservation) }
        };

        public DBList()
        {
            this.username = "root";
            this.password = "";
            this.database = "kikeletpanzio";
            list = new ObservableCollection<Object>();
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
                try
                {
                    connection.Open();
                    string sqlCmd = $"SELECT * FROM {table}";
                    using (MySqlCommand mSqlcmd = new MySqlCommand(sqlCmd, connection))
                    using (MySqlDataReader rdr = mSqlcmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(Activator.CreateInstance(type, rdr));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }
            }
        }

        /// <summary>
        /// A kapott objektumot beszúrja az adatbázisba
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="ArgumentException"></exception>
        public void InsertToDB(object obj)
        {
            string insertString = "";

            switch (table)
            {
                case "reservation":
                    insertString = ((ReservationList)this).GetInsertString(obj);
                    break;
                case "RegisteredGuest":
                    insertString = ((RegisteredGuestList)this).GetInsertString(obj);
                    break;
            }

            if (!tableTypes.ContainsKey(table))
            {
                throw new ArgumentException("Nem létező tábla");
            }
            Type type = tableTypes[table];

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conString))
                {
                    connection.Open();
                    string sqlCmd = insertString;
                    using (MySqlCommand mSqlcmd = new MySqlCommand(sqlCmd, connection))
                    {
                        mSqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException)
            {
                throw new Exception("Hiba az adatbázisba való beszúrás során");
            }
        }

        /// <summary>
        /// Az adatbázisból lekéri az utolsó rekordot
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void GetLastFromDB()
        {
            if (!tableTypes.ContainsKey(table))
            {
                throw new ArgumentException("Nem létező tábla");
            }
            Type type = tableTypes[table];

            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();
                string sqlCmd = $"SELECT * FROM {table} ORDER BY ID DESC LIMIT 1";
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

        /// <summary>
        /// A kapott objektumot módosítja az adatbázisban
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateDB(object obj)
        {
            string updateString = "";

            switch (table)
            {
                case "reservation":
                    updateString = ((ReservationList)this).GetUpdateString(obj);
                    break;
                case "RegisteredGuest":
                    updateString = ((RegisteredGuestList)this).GetUpdateString(obj);
                    break;
            }
            try
            {
                using (MySqlConnection connection = new MySqlConnection(conString))
                {
                    connection.Open();
                    string sqlCmd = updateString;
                    using (MySqlCommand mSqlcmd = new MySqlCommand(sqlCmd, connection))
                    {
                        mSqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        /// <summary>
        /// A kapott indexű rekordot törli az adatbázisból
        /// </summary>
        /// <param name="index"></param>
        public void DeleteFromDB(int index)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection())
                {
                    connection.Open();
                    string sqlCmd = $"DELETE FROM {table} WHERE {table}Id = {index}";
                    using (MySqlCommand mSqlcmd = new MySqlCommand(sqlCmd, connection))
                    {
                        mSqlcmd.ExecuteNonQuery();
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

    }

    internal class RoomList : DBList
    {
        public RoomList()
        {
            table = "room";
        }
    }

    internal class RegisteredGuestList : DBList
    {
        public RegisteredGuestList()
        {
            table = "RegisteredGuest";
        }

        public string GetInsertString(object obj)
        {
            return $"INSERT INTO RegisteredGuest (guestCode, guestName, birthDay, country, postalCode, city, address, email, vip, banned) VALUES (\"{((RegisteredGuest)obj).guestCode}\" ,\"{((RegisteredGuest)obj).guestName}\", \"{((RegisteredGuest)obj).birthDay.ToString("yyyy-MM-dd HH:mm:ss")}\", \"{((RegisteredGuest)obj).country}\", \"{((RegisteredGuest)obj).postalCode}\", \"{((RegisteredGuest)obj).city}\", \"{((RegisteredGuest)obj).address}\", \"{((RegisteredGuest)obj).email}\", {((RegisteredGuest)obj).vip}, {((RegisteredGuest)obj).banned})";
        }

        public string GetUpdateString(object obj)
        {
            return $"UPDATE {table} SET guestCode = \"{((RegisteredGuest)obj).guestCode}\", guestName=\"{((RegisteredGuest)obj).guestName}\", birthDay = \"{((RegisteredGuest)obj).birthDay.ToString("yyyy-MM-dd HH:mm:ss")}\", country = \"{((RegisteredGuest)obj).country}\", postalCode = \"{((RegisteredGuest)obj).postalCode}\", city = \"{((RegisteredGuest)obj).city}\", address = \"{((RegisteredGuest)obj).address}\", email = {(((RegisteredGuest)obj).email == "" ? "null" : $"\"{((RegisteredGuest)obj).email}\"")}, vip = {((RegisteredGuest)obj).vip}, banned = {((RegisteredGuest)obj).banned} WHERE ID = {((RegisteredGuest)obj).guestId}";
        }
    }

    internal class ReservationList : DBList
    {
        public ReservationList()
        {
            table = "reservation";
        }

        public string GetInsertString(object obj)
        {
            return $"INSERT INTO reservation (guestID, roomID, firstReservedDay, lastReservedDay) VALUES ({((Reservation)obj).guestID}, {((Reservation)obj).roomID}, '{((Reservation)obj).firstReservedDay.ToString("yyyy-MM-dd HH:mm:ss")}', '{((Reservation)obj).lastReservedDay.ToString("yyyy-MM-dd HH:mm:ss")}')";
        }

        public string GetUpdateString(object obj)
        {
            return $"UPDATE {table} SET guestID = {((Reservation)obj).guestID}, roomID = {((Reservation)obj).roomID}, firstReservedDay = '{((Reservation)obj).firstReservedDay.ToString("yyyy-MM-dd HH:mm:ss")}', lastReservedDay = '{((Reservation)obj).lastReservedDay.ToString("yyyy-MM-dd HH:mm:ss")}', reservationStatus = '{((Reservation)obj).reservationStatus}' WHERE ID = {((Reservation)obj).reservationId}";
        }
    }
}
