using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kikelet_Panzió
{
    public class Room
    {
        //Egy szoba adatai
        public int roomId { get; }
        public int roomNumber { get; }
        public int accommodation { get; }  //Férőhelyek száma
        public int price { get; }

        public Room(int roomId, int roomNumber, int accommodation, int price)
        {
            this.roomId = roomId;
            this.roomNumber = roomNumber;
            this.accommodation = accommodation;
            this.price = price;
        }

    }
}