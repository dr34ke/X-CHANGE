using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using app.Data;
using app.Models;

namespace app.Data
{
    class SettingsController
    {
        static object locker = new object();
        public static SQLiteConnection database;
        public SettingsController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<SettingsDB>();
        }
        public SettingsDB GetSettings()
        {
            lock (locker)
            {
                if (database.Table<SettingsDB>().Count() == 0)
                {
                    database.Insert(new SettingsDB
                    {
                        id = 1,
                        time = "12:34:56",
                        enablepush = false,
                        settings = "usd-False;aud-False;cad-False;eur-False;huf-False;chf-False;gbp-False;jpy-False;czk-False;dkk-False;nok-False;sek-False;xdr-False"
                    });
                    return GetSettings();
                }
                else
                {
                    return database.Table<SettingsDB>().First();
                }
            }

        }
        public static void SetSettings(SettingsDB settings)
        {
            lock(locker)
            {
                database.Update(settings);
            }
        }
    }
}
