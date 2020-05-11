using System;
using System.Collections.Generic;
using System.Text;

namespace app.Models
{
    class Table
    {
        public string table { get; set; }
        public string no { get; set; }
        public string tradingDate { get; set; }
        public string effectiveDate { get; set; }
        public Rates rates {get;set;}
        public Table()
        {

        }
    }
    class Rates
    {

    }
}
