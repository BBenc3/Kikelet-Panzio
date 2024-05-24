﻿using MySqlConnector;
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

        public Room(MySqlDataReader rdr)
        {
            this.roomId = (int)rdr[0];
            this.roomNumber = (int)rdr[1];
            this.accommodation = (int)rdr[2];
            this.price = (int)rdr[3];
        }

        public Room(int roomId, int roomNumber, int accommodation, int price)
        {
            this.roomId = roomId;
            this.roomNumber = roomNumber;
            this.accommodation = accommodation;
            this.price = price;
        }

        public override string ToString()
        {
            return $"\"{roomNumber}\", {accommodation}, {price}";
        }
    }
}