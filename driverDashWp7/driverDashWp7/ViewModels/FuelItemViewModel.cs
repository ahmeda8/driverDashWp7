using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace driverDashWp7.ViewModels
{
    public class FuelItemViewModel : ViewModelBase
    {
        private string _date;
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                NotifyPropertyChanged("Date");
            }
        }

        private string _time;
        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                NotifyPropertyChanged("Time");
            }
        }

        private int _id;
        public int FuelID
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged("FuelID"); }
        }

        private string _mpg;
        public string MPG
        {
            get { return _mpg; }
            set { _mpg = value; NotifyPropertyChanged("MPG"); }
        }

        private string _miles;
        public string Miles
        {
            get { return _miles; }
            set { _miles = value; NotifyPropertyChanged("Miles"); }
        }

        private string _vol;
        public string Vol
        {
            get { return _vol; }
            set { _vol = value; NotifyPropertyChanged("Vol"); }
        }

        private string _cost;
        public string Cost
        {
            get { return _cost; }
            set { _cost = value; NotifyPropertyChanged("Cost"); }
        }
    }
}
