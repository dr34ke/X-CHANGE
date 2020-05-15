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
        public List<setting> SettingsCur { get => _SettingsCur; set
            {
                this._SettingsCur=value;
                OnPropertyChanged(nameof(_SettingsCur));
            } 
        }
        private List<setting> _SettingsCur { get; set; }
        public SettingsDB set { get=>_set; set
            {
                _set = value;
                this.SettingsCur = new List<setting>();
                foreach(string str in value.settings.Split(';'))
                {
                    try
                    {
                        SettingsCur.Add(new setting() { name=str.Split('-')[0].ToUpper(), isSet=bool.Parse(str.Split('-')[1]) });
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
            for (var i=0; i< SettingsCur.Count; i++)
            {
                this.set.settings += SettingsCur[i].name + "-" + SettingsCur.ElementAtOrDefault(i).isSet.ToString() + ";";
            }
            app.Data.SettingsController.SetSettings(this.set);
        }
    }
}
