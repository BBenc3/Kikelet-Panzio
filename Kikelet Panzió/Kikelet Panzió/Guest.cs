using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kikelet_Panzió
{
    public class Guest
    {
        private string guestName;
        private string guestId;
        private DateTime birthDay;
        private bool vip;
        private bool canBeVip;
        private DateTime registrationDate;
        private int postalCode;
        private string city;
        private string address;
        private string country;
        private bool banned;

        public Guest(string guestName, int id, DateTime birthDay, bool vip, bool canBeVip, DateTime registrationDate, int postalCode, string city, string address, string country, bool banned)
        {
            this.GuestName = guestName;
            this.GuestId = id;
            this.BirthDay = birthDay;
            this.Vip = vip;
            this.CanBeVip = canBeVip;
            this.RegistrationDate = registrationDate;
            this.PostalCode = postalCode;
            this.City = city;
            this.Address = address;
            this.Country = country;
            this.Banned = banned;
        }

        public string GuestName { get => guestName; set => guestName = value; }
        public string GuestId { get => guestId; set => guestId = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public bool Vip { get => vip; set => vip = value; }
        public bool CanBeVip { get => canBeVip; set => canBeVip = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public int PostalCode { get => postalCode; set => postalCode = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public string Country { get => country; set => country = value; }
        public bool Banned { get => banned; set => banned = value; }
    }
}