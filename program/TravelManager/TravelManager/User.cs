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
using Google.Apis.Auth;
using MailKit;
using MimeKit;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;

namespace TravelManager
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        //TODO: пофіксити проблему з доступом для бд і відправлення мейлів
        public int id { get;  set; }
        public string Fio { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string token { get; set; }

        public User() { }
        public void generateToken()
        {
            Random random = new Random();
            int token = random.Next(10000000, 9999999);

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Travel manager", "noreply@localhost.com"));
            message.To.Add(new MailboxAddress("user", mail));
            message.Subject = "registration token";
            message.Body = new TextPart("plain") { Text = token.ToString() };
            MailKit.Net.Smtp.SmtpClient smtp = new MailKit.Net.Smtp.SmtpClient();

            smtp.Connect("smtp.gmail.com", 587);

            //TODO: створити мейл для розсилки
            smtp.Authenticate("mail","password");

            smtp.Send(message);

            this.token = token.ToString();
        }
        public User(string mail, string password)
        {
            this.mail = mail;
            this.password = password;
        }
    }
}