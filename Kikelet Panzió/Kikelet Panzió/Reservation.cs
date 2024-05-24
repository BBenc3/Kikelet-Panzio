using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kikelet_Panzió
{
    public class Reservation
    {
        // Egy foglalás adatai
        public int reservationId { get; }
        public DateTime checkedIn { get; set; } //Mikor jött meg
        public DateTime checkedOut { get; set; } //Mikor ment el
        public int guestId { get; set; } //Melyik vendég
        public RegisteredGuest guest { get; set; }
        public int roomId { get; set; } //Melyik szobában
        public Room room { get; set; }
        public DateTime dateOfReservation { get; } //Melyik napon foglalt
        public DateTime firstReservedDay { get; set; } //Melyik naptól
        public DateTime lastReservedDay { get; set; } //Meddig
        public string reservationStatus { get; set; } //Foglalás státusza
        public int stayed { get; set; } //Hány éjszakát maradt, származtatott adat
        public double total { get; set; }

        //For database
        public Reservation(MySqlDataReader rdr)
        {
            this.reservationId = (int)rdr[0];
            this.checkedIn = (DateTime)rdr[1];
            this.checkedOut = (DateTime)rdr[2];
            this.guestId = (int)rdr[4];
            this.guest = MainWindow.guests.FirstOrDefault(x => x.guestId == this.guestId);
            this.roomId = (int)rdr[5];
            this.room = MainWindow.rooms.FirstOrDefault(x => x.roomId == this.roomId); ;
            this.dateOfReservation = (DateTime)rdr[6];
            this.firstReservedDay = (DateTime)rdr[7];
            this.lastReservedDay = (DateTime)rdr[8];
            this.stayed = (lastReservedDay - firstReservedDay).Days;
            this.total = guest.vip ? (room.price * stayed)*0.3 : room.price * stayed;
        }

        public override string ToString()
        {
            return $"\"{checkedIn}\", \"{checkedOut}\", {guestId}, {roomId}, \"{firstReservedDay}\", \"{lastReservedDay}\", \"{reservationStatus}\"";
        }
    }
}