using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kikelet_Panzió
{
    public class RegisteredGuest
    {
        //Egy regissztrált felhasználó adatai

        public string guestId { get; } //A felhassználó nevéből és regisztráció dátumából generálódik
        public DateTime registrationDate { get; }
        public string guestName { get; set; }
        public DateTime birthDay { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public bool vip { get; set; }
        public bool canBeVip { get; } //Abban az esetben igaz, ha a felhasználó e-mailcíme be van állítva
        public bool banned { get; set; } //A felhaszbáló inaktív megszünnek ha az érték igaz

        //For database
        public RegisteredGuest(string guestId, DateTime registrationDate, string guestName, DateTime birthDay, string country, string postalCode, string city, string address, string eamil, bool vip, bool canBeVip, bool banned)
        {
            this.guestId = guestId;
            this.registrationDate = registrationDate;
            this.guestName = guestName;
            this.birthDay = birthDay;
            this.country = country;
            this.postalCode = postalCode;
            this.city = city;
            this.address = address;
            this.email = eamil;
            this.vip = vip;
            this.canBeVip = canBeVip;
            this.banned = banned;
        }

        //For new guest
        public RegisteredGuest(string guestName, DateTime birthDay, string country, string postalCode, string city, string address, string eamil, bool vip, bool canBeVip)
        {
            this.guestId = guestName.Replace(" ", "") + registrationDate.ToString().Replace(".", "").Replace(":", "").Replace(" ", "");
            this.registrationDate = DateTime.Now;
            this.guestName = guestName;
            this.birthDay = birthDay;
            this.country = country;
            this.postalCode = postalCode;
            this.city = city;
            this.address = address;
            this.email = eamil;
            this.vip = vip;
            this.canBeVip = email != "" ;
        }
    }
}