using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kikelet_Panzió
{
    public class Reservation
    {
        // Egy foglalás adatai
        public int reservationNumber { get; }
        public DateTime checkedIn { get; set; } //Mikor jött meg
        public DateTime checkedOut { get; set; } //Mikor ment el
        public Guest guest { get; set; }
        public Room room { get; set; }
        public int total { get; set; }
        public int dateOfReservation { get; set; } //Melyik napon foglalt
        public int firstReservedDay { get; set; } //Melyik naptól
        public int lastReservedDay { get; set; } //Meddig

        public Reservation()
        {
            throw new System.NotImplementedException();
        }
    }
}