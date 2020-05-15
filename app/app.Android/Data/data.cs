using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using app.Data;
using app.Droid.Data;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(data))]

namespace app.Droid.Data
{
    class data : ISQLite
    {

        public data() {}
        public SQLite.SQLiteConnection GetConnection()
        {
        var sqliteFileName = "TestDB.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFileName);
            var con = new SQLite.SQLiteConnection(path);
            return con;
        }
    }
}