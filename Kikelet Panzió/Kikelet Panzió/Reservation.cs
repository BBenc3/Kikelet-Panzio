using MySqlConnector;

namespace Kikelet_Panzió
{
    public class Reservation
    {
        // Egy foglalás adatai
        public int reservationId { get; }
        public DateTime checkedIn { get; set; } //Mikor jött meg
        public DateTime checkedOut { get; set; } //Mikor ment el
        public int guestId { get; set; } //Melyik vendég
        public RegisteredGuest guest { get; }
        public int roomId { get; set; } //Melyik szobában
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
            this.checkedIn = (DateTime)rdr[1];
            this.checkedOut = (DateTime)rdr[2];
            this.guestId = (int)rdr[4];
            //this.guest = MainWindow.guests.FirstOrDefault(x => x.guestId == this.guestId);
            this.roomId = (int)rdr[5];
            //this.room = MainWindow.rooms.FirstOrDefault(x => x.roomId == this.roomId); ;
            this.dateOfReservation = (DateTime)rdr[6];
            this.firstReservedDay = (DateTime)rdr[7];
            this.lastReservedDay = (DateTime)rdr[8];
            this.stayed = (lastReservedDay - firstReservedDay).Days;
            this.total = guest.vip ? (room.price * stayed) * 0.03 : room.price * stayed;
        }

        //For new reservation
        public Reservation(DateTime checkedIn, DateTime checkedOut, int guestId, int roomId, DateTime firstReservedDay, DateTime lastReservedDay, string reservationStatus)
        {
            this.checkedIn = checkedIn;
            this.checkedOut = checkedOut;
            this.guestId = guestId;
            this.roomId = roomId;
            this.dateOfReservation = dateOfReservation;
            this.firstReservedDay = firstReservedDay;
            this.lastReservedDay = lastReservedDay;
            this.reservationStatus = reservationStatus;
        }

        public override string ToString()
        {
            return $"\"{checkedIn}\", \"{checkedOut}\", {guestId}, {roomId}, \"{firstReservedDay}\", \"{lastReservedDay}\", \"{reservationStatus}\"";
        }
    }
}