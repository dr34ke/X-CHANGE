


using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;

namespace app.Models
{
    public class Table
    {
        public string table { get; set; }
        public string no { get; set; }
        public string tradingDate { get; set; }
        public string effectiveDate { get; set; }
        public List<Rates> rates { get; set; }
        public Table()
        {
            RestClient client = new RestClient("https://api.nbp.pl/api/exchangerates/tables/c/");
            RestRequest request = new RestRequest();
            request.AddParameter("format", "json");
            var res = client.Execute(request);
            List<_Table> obj = JsonConvert.DeserializeObject<List<_Table>>(res.Content);
            this.table = obj[0].table;
            this.no = obj[0].no;
            this.tradingDate = obj[0].tradingDate;
            this.effectiveDate = obj[0].effectiveDate;
            this.rates = obj[0].rates;

        }
    }
    public class _Table
    {
        public string table { get; set; }
        public string no { get; set; }
        public string tradingDate { get; set; }
        public string effectiveDate { get; set; }
        public List<Rates> rates { get; set; }
    }
    public class Rates
    {
        public string currency { get; set; }
        public string code { get; set; }
        public float bid { get; set; }
        public float ask { get; set; }


    }
}

