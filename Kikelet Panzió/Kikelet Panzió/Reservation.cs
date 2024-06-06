using MySqlConnector;

namespace Kikelet_Panzió
{
    public class Reservation
    {
        // Egy foglalás adatai
        public int reservationId { get; }
        public DateTime checkedIn { get; set; } //Mikor jött meg
        public DateTime checkedOut { get; set; } //Mikor ment el
        public int guestID { get; set; } //Melyik vendég
        public RegisteredGuest guest { get; }
        public int roomID { get; set; } //Melyik szobában
        public Room room { get; }
        public DateTime dateOfReservation { get; } //Melyik napon foglalt
        public DateTime firstReservedDay { get; set; } //Melyik naptól
        public DateTime lastReservedDay { get; set; } //Meddig
        public string reservationStatus { get; set; } //Foglalás státusza
        public int stayed { get; } //Hány éjszakát maradt, származtatott adat
        public double total { get; }

        //For database
        public Reservation(MySqlDataReader rdr)
        {
            this.reservationId = (int)rdr[0];
            this.checkedIn = rdr[1] != DBNull.Value ? (DateTime)rdr[1] : default;
            this.checkedOut = rdr[2] != DBNull.Value ? (DateTime)rdr[2] : default;
            this.guestID = (int)rdr[3];
            this.guest = MainWindow.registeredGuestList.list.Select(x => (RegisteredGuest)x).FirstOrDefault(x => x.guestId == this.guestID);
            this.roomID = (int)rdr[4];
            this.room = MainWindow.roomList.list.Select(x => (Room)x).FirstOrDefault(x => x.roomId == this.roomID);
            this.dateOfReservation = (DateTime)rdr[5];
            this.firstReservedDay = (DateTime)rdr[6];
            this.lastReservedDay = (DateTime)rdr[7];
            this.reservationStatus = (string)rdr[8];
            this.stayed = (lastReservedDay - firstReservedDay).Days;
            this.total = guest.vip ? Math.Abs((room.price * stayed) * 0.03) : Math.Abs(room.price * stayed);
        }

        //For new reservation
        public Reservation(int guestId, int roomId, DateTime firstReservedDay, DateTime lastReservedDay)
        {
            this.guestID = guestId;
            this.roomID = roomId;
            this.dateOfReservation = DateTime.Now;
            this.firstReservedDay = firstReservedDay;
            this.lastReservedDay = lastReservedDay;
            this.reservationStatus = "Open";
        }

    }
}