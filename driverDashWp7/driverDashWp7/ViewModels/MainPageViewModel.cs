using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using driverDashWp7.Models;

namespace driverDashWp7.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DatabaseModel db;

        private ObservableCollection<CarViewModel> _carCollection;
        public ObservableCollection<CarViewModel> Cars
        {
            get { return _carCollection; }
            set
            {
                _carCollection = value;
                NotifyPropertyChanged("CarCollection");
            }
        }

        

        public MainPageViewModel()
        {
            db = DatabaseModel.GetInstance(App.DB_CONNECTION);
            db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.CarTable);
            Cars = new ObservableCollection<CarViewModel>();

            var allCarsQuery = from Car c in db.CarTable
                               select c;
            foreach (Car c in allCarsQuery.ToArray())
            {
                Cars.Add(new CarViewModel(c.CarID) { Make=c.Make, Lic=c.License, Model=c.Model, Year = c.Year });
            }
        }

        
    }
}
