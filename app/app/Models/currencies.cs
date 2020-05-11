


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
        private string _cur {get;set;} 
        public string currency
        {
            get => _cur; 
            set
            {
                string[] a =value.Split(' ');
                char[] b;
                foreach (string _a in a)
                {
                    b = _a.ToCharArray();
                    b[0]=char.Parse(b[0].ToString().ToUpper());
                    foreach(char p in b)
                    {
                        _cur += p.ToString();
                    }
                    _cur += " ";
                }
                _cur = _cur.Trim(' ');
            }
        }
        public string code { get; set; }
        public float bid { get; set; }
        public float ask { get; set; }
    }
    public class detailResponse
    {
        public string table { get; set; }
        private string _cur {get;set;}
        public string currency
        {
            get => _cur;
            set
            {
                string[] a = value.Split(' ');
                char[] b;
                foreach (string _a in a)
                {
                    b = _a.ToCharArray();
                    b[0] = char.Parse(b[0].ToString().ToUpper());
                    foreach (char p in b)
                    {
                        _cur += p.ToString();
                    }
                    _cur += " ";
                }
                _cur = _cur.Trim(' ');
            }
        }
        public string code { get; set; }
        public List<detailRates> rates { get; set; }
        public detailResponse(string code)
        {
            RestClient client = new RestClient("http://api.nbp.pl/api/exchangerates/rates/c/" + code + "/");
            RestRequest request = new RestRequest();
            request.AddParameter("format", "json");
            var res = client.Execute(request);
            detailResponse obj = JsonConvert.DeserializeObject<detailResponse>(res.Content);
            this.table = obj.table;
            this.currency = obj.currency;
            this.code = obj.code;
            this.rates = obj.rates;
        }
        public class detailRates
        {
            public string no { get; set; }
            public string effectiveDate { get; set; }
            public float ask { get; set; }
            public float bid { get; set; }
        }
    }
}

