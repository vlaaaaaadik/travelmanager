using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace TravelManager
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get;  set; }
        public string Fio { get; private set; }
        public string mail { get; private set; }
        public string password { get; private set; }
        public string token { get; private set; }

        public User() { }
        public void generateToken()
        {
            Random random = new Random();
            int token = random.Next(10000, 99999);
            MailAddress address = new MailAddress(this.mail);
            MailAddress me = new MailAddress("test");
            MailMessage message = new MailMessage(me, address);
            message.Subject = "token";
            message.IsBodyHtml = false;
            message.Body = token.ToString();
            

            this.token = token.ToString();
        }
        public User(string mail, string password)
        {
            this.mail = mail;
            this.password = password;
        }
    }
}