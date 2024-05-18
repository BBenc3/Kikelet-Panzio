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
        public int stayed { get; set; } //Hány éjszakát maradt, származtatott adat
        public int roomNumber { get; set; } //Melyik szobában
        public string guestId { get; set; } //Melyik vendég
        public RegisteredGuest guest { get; set; }
        public Room room { get; set; }
        public double total { get; set; }
        public DateTime dateOfReservation { get; } //Melyik napon foglalt
        public DateTime firstReservedDay { get; set; } //Melyik naptól
        public DateTime lastReservedDay { get; set; } //Meddig

        public Reservation(int reservationId, DateTime checkedIn, DateTime checkedOut, RegisteredGuest guest, Room room, DateTime firstReservedDay, DateTime lastReservedDay)
        {
            this.reservationId = reservationId;
            this.checkedIn = checkedIn;
            this.checkedOut = checkedOut;
            this.guest = guest;
            this.room = room;
            this.stayed = (checkedOut - checkedIn).Days;
            this.total = guest.vip ? room.price * stayed * 0.3 : room.price * stayed;
            this.dateOfReservation = DateTime.Today;
            this.firstReservedDay = firstReservedDay;
            this.lastReservedDay = lastReservedDay;
        }
    }
}