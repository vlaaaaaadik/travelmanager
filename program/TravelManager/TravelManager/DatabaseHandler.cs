using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace TravelManager
{
    class DatabaseHandler 
    {
        public string dbName { get; private set; }
        public string dbPath { get; private set; }
        public SQLiteConnection connection { get; private set; }
        public DatabaseHandler()
        {
            dbName = "data.sqlite";
            dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),dbName);
            connection = new SQLiteConnection(dbPath);
        }
    }
}