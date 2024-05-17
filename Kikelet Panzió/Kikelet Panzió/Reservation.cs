using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kikelet_Panzió
{
    public class Reservation
    {
        private DateTime checkedIn;
        private DateTime checkedOut;
        private Guest guest;
        private Room room;
        private int total;
        private int dateOfReservation;
        private int firstReservedDay;
        private int lastReservedDay;

        public Reservation()
        {
            throw new System.NotImplementedException();
        }
    }
}