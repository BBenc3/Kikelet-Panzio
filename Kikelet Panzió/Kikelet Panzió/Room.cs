using MySqlConnector;

namespace Kikelet_Panzió
{
    public class Room
    {
        //Egy szoba adatai
        public int roomId { get; }
        public string roomNumber { get; }
        public int accommodation { get; }  //Férőhelyek száma
        public int price { get; }

        public Room(MySqlDataReader rdr)
        {
            this.roomId = (int)rdr[0];
            this.roomNumber = (string)rdr[1];
            this.accommodation = (int)rdr[2];
            this.price = (int)rdr[3];
        }

        public Room(int roomId, string roomNumber, int accommodation, int price)
        {
            this.roomId = roomId;
            this.roomNumber = roomNumber;
            this.accommodation = accommodation;
            this.price = price;
        }

        public override string ToString()
        {
            return roomNumber;
        }
    }
}