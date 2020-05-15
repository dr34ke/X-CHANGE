using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.Data
{
    public interface ISQLite 
    {
        SQLiteConnection GetConnection();
    }
}
