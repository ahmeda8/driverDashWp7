using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

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
            Cars = new ObservableCollection<CarViewModel>();

            var allCarsQuery = from carInfo c in db.carInfo
                               select c;
            foreach (carInfo c in allCarsQuery.ToArray())
            {
                Cars.Add(new CarViewModel { ID=c.CarID, Make=c.CarMake, Lic=c.CarLic, Model=c.CarModel, Year = c.CarYear });
            }
        }

        
    }
}
