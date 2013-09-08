using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;

namespace driverDashWp7.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private string _distance;
        public string Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                IsolatedStorageSettings.ApplicationSettings["distance"] = _distance;
                IsolatedStorageSettings.ApplicationSettings.Save();
                Msg = "Settings Saved";
                NotifyPropertyChanged("Distance");
            }
        }

        private string _vol;
        public string Vol
        {
            get { return _vol; }
            set
            {
                _vol = value;
                IsolatedStorageSettings.ApplicationSettings["vol"] = _vol;
                IsolatedStorageSettings.ApplicationSettings.Save();
                Msg = "Settings Saved";
                NotifyPropertyChanged("Vol");
            }
        }

        private string _curr;
        public string Currency
        {
            get { return _curr; }
            set
            {
                _curr = value;
                IsolatedStorageSettings.ApplicationSettings["currency"] = _curr;
                IsolatedStorageSettings.ApplicationSettings.Save();
                Msg = "Settings Saved";
                NotifyPropertyChanged("Currency");
            }
        }

        private string _msg;
        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                NotifyPropertyChanged("Msg");
            }
        }

        private bool _AvgMethod;
        public bool Avgmethod
        {
            get { return _AvgMethod; }
            set
            {
                _AvgMethod = value;
                IsolatedStorageSettings.ApplicationSettings["avgmethod"] = _AvgMethod;
                IsolatedStorageSettings.ApplicationSettings.Save();
                Msg = "Settings Saved";
                NotifyPropertyChanged("Avgmethod");
            }
        }

        public string MPG
        {
            get {
                return Distance.Substring(0,2)+"/"+Vol.Substring(0,1); 
            }
            
        }

        public SettingsPageViewModel()
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains("appinit"))
            {
                IsolatedStorageSettings.ApplicationSettings.Add("appinit", true);
                IsolatedStorageSettings.ApplicationSettings.Add("distance", "miles");
                IsolatedStorageSettings.ApplicationSettings.Add("vol", "gals");
                IsolatedStorageSettings.ApplicationSettings.Add("currency", "$");
                IsolatedStorageSettings.ApplicationSettings.Add("avgmethod",false);
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
            Distance = (string)IsolatedStorageSettings.ApplicationSettings["distance"];
            Vol = (string)IsolatedStorageSettings.ApplicationSettings["vol"];
            Currency = (string)IsolatedStorageSettings.ApplicationSettings["currency"];
            Avgmethod = (bool)IsolatedStorageSettings.ApplicationSettings["avgmethod"];
            Msg = "Changing any value will automatically save settings.";
        }
    }
}
