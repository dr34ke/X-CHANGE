

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using app.Models;
namespace app.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        public MainVM()
        {
            this.tab = new Table();
            this.rat = new ObservableCollection<Rates>();
            foreach (Rates rates in tab.rates)
            {
                this.rat.Add(rates);
            }
        }
        public Table tab { get; set; }
        public ObservableCollection<Rates> rat { get; set; }
        private List<Rates> _rates { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}