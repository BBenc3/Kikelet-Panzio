using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kikelet_Panzió
{
    public class Guest
    {
        //Egy regissztrált felhasználó adatai

        public string guestId { get; } //A felhassználó nevéből és regisztráció dátumából generálódik
        public DateTime registrationDate { get; }
        public string guestName { get; set; }
        public DateTime birthDay { get; set; }
        public string country { get; set; }
        public int postalCode { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public bool vip { get; set; }
        public bool canBeVip { get; } //Abban az esetben igaz, ha a felhasználó e-mailcíme be van állítva
        public bool banned { get; set; } //A felhaszbáló inaktív megszünnek ha az érték igaz
        
    }
}