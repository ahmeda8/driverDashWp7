using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using driverDashWp7.Models;

namespace driverDashWp7.ViewModels
{
    public class FuelPageViewModel : ViewModelBase
    {
        private ObservableCollection<FuelItemViewModel> _fuelList;
        public ObservableCollection<FuelItemViewModel> FuelList
        {
            get
            { return _fuelList; }
            set
            {
                _fuelList = value;
                NotifyPropertyChanged("FuelList");
            }
        }

        private int _carID;
        public int CarID
        {
            get
            {
                return _carID;
            }
            set
            {
                _carID = value;
                NotifyPropertyChanged("CarID");
            }
        }

        public FuelPageViewModel(int carID)
        {
            DatabaseModel db = DatabaseModel.GetInstance(App.DB_CONNECTION);
            var fuelQuery = from Fuel f in db.FuelTable
                            where f.CarID == carID
                            orderby f.Created descending
                            select f;
            FuelList = new ObservableCollection<FuelItemViewModel>();
            CarID = carID;
            foreach (Fuel f in fuelQuery.ToArray())
            {
                FuelList.Add(new FuelItemViewModel { Date = f.Created.ToShortDateString() });
            }
        }

    }
}
