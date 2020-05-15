using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using app.Data;
using app.Models;
using Xamarin.Forms;

namespace app.ViewModels
{
    class SettingsVM : INotifyProprtyChanged
    {
        public ICommand command { get; set; }
        ObservableCollection<KeyValuePair<string, bool>> sett;
        public SettingsDB set { get=>_set; set
            {
                _set = value;
                this.sett = new ObservableCollection<KeyValuePair<string, bool>>();
                foreach(string str in value.settings.Split(';'))
                {
                    try
                    {
                        sett.Add(new KeyValuePair<string, bool>(str.Split('-')[0].ToUpper(), bool.Parse(str.Split('-')[1])));
                    }
                    catch{
                       var x = 1;
                    }
                   
                }
                OnPropertyChanged(nameof(_set));
            }
        }
        private SettingsDB _set { get; set; }
        public SettingsVM() 
        {
            SettingsController settings = new SettingsController();
            this.command = new Command(Save);
            set=settings.GetSettings();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void Save()
        {
            this.set.settings = "";
            for (var i=0; i<sett.Count; i++)
            {
                this.set.settings += sett[i].Key + "-" + sett.ElementAtOrDefault(i).Value.ToString() + ";";
            }
            app.Data.SettingsController.SetSettings(this.set);
        }
    }
}
