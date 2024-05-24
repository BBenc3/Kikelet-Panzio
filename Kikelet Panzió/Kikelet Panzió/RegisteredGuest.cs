﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MySqlConnector;

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
        public RegisteredGuest(MySqlDataReader rdr)
        {
            this.guestId = (int)rdr[0];
            this.guestCode = (string)rdr[1];
            this.registrationDate = (DateTime)rdr[3];
            this.guestName = (string)rdr[4];
            this.birthDay = (DateTime)rdr[5];
            this.country = (string)rdr[6];
            this.postalCode = (string)rdr[7];
            this.city = (string)rdr[8];
            this.address = (string)rdr[9];
            this.email = (string)rdr[10];
            this.vip = (bool)rdr[11];
            this.canBeVip = email != null;
            this.banned = (bool)rdr[12];
        }
        #endregion


        //A konstruktor paramétereit közvetlenül el kell küldeni az adatbnek (kidolgozni)
        public RegisteredGuest(string guestCode, string guestName, DateTime birthDay, string country, string postalCode, string city, string address, string email, bool vip, bool banned)
        {
            this.guestCode = guestName + registrationDate.ToString("yyyyMMdd"); ;
            this.guestName = guestName;
            this.birthDay = birthDay;
            this.country = country;
            this.postalCode = postalCode;
            this.city = city;
            this.address = address;
            this.email = email;
            this.banned = banned;
        }

        public override string ToString()
        {
            return $"\"{guestCode}\" ,\"{guestName}\", \"{birthDay}\", \"{country}\", \"{postalCode}\", \"{city}\", \"{address}\", \"{email}\", {vip}, {banned}";
        }
    }

}