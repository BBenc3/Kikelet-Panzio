using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kikelet_Panzió
{
    public class RegisteredGuest
    {
        //Egy regissztrált felhasználó adatai

        public int guestId { get; } //A felhassználó nevéből és regisztráció dátumából generálódik
        public string guestCode { get; }
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

        #region For database
        public RegisteredGuest(int guestId, string guestCode, DateTime registrationDate, string guestName, DateTime birthDay, string country, string postalCode, string city, string address, string email, bool vip, bool banned)
        {
            this.guestId = guestId;
            this.guestCode = guestCode;
            this.registrationDate = registrationDate;
            this.guestName = guestName;
            this.birthDay = birthDay;
            this.country = country;
            this.postalCode = postalCode;
            this.city = city;
            this.address = address;
            this.email = email;
            this.vip = vip;
            this.canBeVip = email != null;
            this.banned = banned;
        }
        #endregion


        public RegisteredGuest(string guestCode, DateTime registrationDate, string guestName, DateTime birthDay, string country, string postalCode, string city, string address, string email, bool vip, bool banned)
        {
            this.guestCode = guestName + registrationDate.ToString("yyyyMMdd"); ;
            this.registrationDate = DateTime.Now;
            this.guestName = guestName;
            this.birthDay = birthDay;
            this.country = country;
            this.postalCode = postalCode;
            this.city = city;
            this.address = address;
            this.email = email;
            this.banned = banned;
        }

    }
}