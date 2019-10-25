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
        public string sqliteFilename;
        public string libraryPath;
        public string path;
        public SQLiteConnection database;

        public DatabaseHandler()
        {
            sqliteFilename = "newdb.sqlite";
            libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = System.IO.Path.Combine(libraryPath, sqliteFilename);
            database = new SQLiteConnection(path);
        }
    }
}