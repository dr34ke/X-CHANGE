using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;
namespace app.Models
{
    class SettingsDB
    {
        [PrimaryKey] 
        public int id { get; set; }
        public string settings { get; set; }
        public string time { get; set; }
        public bool enablepush { get; set; }
    }
}
