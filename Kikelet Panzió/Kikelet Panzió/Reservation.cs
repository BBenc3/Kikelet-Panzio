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
        public int stayed { get; set; } //Hány éjszakát maradt, származtatott adat
        public double total { get; set; }

        public Reservation(int reservationId, DateTime checkedIn, DateTime checkedOut, int guestId, int roomId, DateTime dateOfReservation, DateTime firstReservedDay, DateTime lastReservedDay)
        {
            this.reservationId = reservationId;
            this.checkedIn = checkedIn;
            this.checkedOut = checkedOut;
            this.guestId = guestId;
            this.guest = MainWindow.guests.FirstOrDefault(x => x.guestId == this.guestId);
            this.roomId = roomId;
            this.room = MainWindow.rooms.FirstOrDefault(x => x.roomId == this.roomId); ;
            this.dateOfReservation = dateOfReservation;
            this.firstReservedDay = firstReservedDay;
            this.lastReservedDay = lastReservedDay;
            this.stayed = (lastReservedDay - firstReservedDay).Days;
            this.total = guest.vip ? (room.price * stayed)*0.3 : room.price * stayed;
        }

    }
}