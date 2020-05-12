using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using app.Models;
using Microcharts;
using Microcharts.Forms;
namespace app.ViewModels
{
    class DetailVM : INotifyPropertyChanged
    {
        public DetailVM(Rates rate)
        {
            detailResponse rateList = new detailResponse(rate.code);
            this.Text = rate.currency;
            this.Entries = entries(rateList.rates);
            this.code = rate.code;
            this.bid = rateList.rates[rateList.rates.Count - 1].bid;
            this.ask = rateList.rates[rateList.rates.Count - 1].ask;
            var chart = new LineChart() { Entries = this.Entries, LabelTextSize = 15 };
            chart.MinValue = (this.minVal / 3) * 2;
            this.Chart = chart;
        }
        public List<Entry> entries(List<detailRates> rates)
        {
            List<Entry> entries = new List<Entry>();
            foreach (detailRates r in rates)
            {
                entries.Add(new Entry(r.bid)
                {
                    ValueLabel = r.bid.ToString(),
                    Label = r.effectiveDate,
                });
                if (this.minVal > r.bid || minVal == 0) this.minVal = r.bid;
            }
            return entries;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public float minVal { get; set; }
        public void OnProprtyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string code { get => _code; set
            {
                _code = value;
                OnProprtyChanged(nameof(_code));
            } }
        private string _code { get; set; }
        public float ask
        {
            get => _ask; set
            {
                _ask = value;
                OnProprtyChanged(nameof(_ask));
            }
        }
        private float _ask { get; set; }
        public float bid
        {
            get => _bid; set
            {
                _bid = value;
                OnProprtyChanged(nameof(_bid));
            }
        }
        private float _bid { get; set; }




        public string Text { get => _Text; set
            {
                _Text = value;
                OnProprtyChanged(nameof(_Text));
            }
        }
        public List<Entry> Entries { get => _Entries; set
            {
                _Entries = value;
                OnProprtyChanged(nameof(_Entries));
            }
        }
        public LineChart Chart
        {
            get => _Chart; set
            {
                _Chart = value;
                OnProprtyChanged(nameof(_Chart));
            }
        }





        public float cur
        {
            get => _cur; set
            {
                _cur = value;
                OnProprtyChanged(nameof(_cur));
            }
        }
        private float _cur { get; set; }
        public float pln
        {
            get => _pln; set
            {
                _pln = value;
                OnProprtyChanged(nameof(_pln));
            }
        }
        private float _pln { get; set; }
        public bool curBool{get=>_curBool;set
            {
                _curBool = value;
                OnProprtyChanged(nameof(_curBool));
            }
        }
        private bool _curBool{get;set;}
        public bool plnBool{
            get => _plnBool; set
            {
                _plnBool = value;
                OnProprtyChanged(nameof(_plnBool));
            }
        }
        private bool _plnBool { get; set; }









        public LineChart _Chart
        {
            get;set;
        }
        public List<Entry> _Entries { get; set; }
        private string _Text { get; set; }
    }
}
