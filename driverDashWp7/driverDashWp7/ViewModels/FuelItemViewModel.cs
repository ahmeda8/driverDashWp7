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
    }
}
