using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace driverDashWp7.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        private DatabaseModel db;

        public MainPageViewModel()
        {
            db = DatabaseModel.GetInstance(App.DB_CONNECTION);
            CarCollection = new ObservableCollection<CarViewModel>();

            var allCarsQuery = from carInfo c in db.carInfo
                               select c;
            foreach (carInfo c in allCarsQuery.ToArray())
            {
                CarCollection.Add(new CarViewModel { ID=c.CarID, Make=c.CarMake, Lic=c.CarLic, Model=c.CarModel, Year = c.CarYear });
            }
        }

        private ObservableCollection<CarViewModel> _carCollection;
        public ObservableCollection<CarViewModel> CarCollection
        {
            get { return _carCollection; }
            set
            {
                _carCollection = value;
                NotifyPropertyChanged("CarCollection");
            }
        }
    }
}
