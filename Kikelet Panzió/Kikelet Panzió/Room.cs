using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kikelet_Panzió
{
    public class Room
    {
        //Egy szoba adatai
        public int roomNumber { get; } //Szoba száma == azonosító
        public int accommodation { get; }  //Férőhelyek száma
        public int price { get; }
        public bool aviable { get; set; }

        public Room(int roomNumber, int accommodation, int price, bool aviable)
        {
            this.roomNumber = roomNumber;
            this.accommodation = accommodation;
            this.price = price;
            this.aviable = aviable;
        }
    }
}