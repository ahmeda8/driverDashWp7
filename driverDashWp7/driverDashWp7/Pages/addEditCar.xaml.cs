using System;
using System.Linq;
using Microsoft.Phone.Controls;
using System.Windows;
using driverDashWp7.ViewModels;

namespace driverDashWp7.Pages
{
    public partial class AddEditCar : PhoneApplicationPage
    {
        private int carID;
        private CarViewModel ViewModel;
        private DatabaseModel db;

        public AddEditCar()
        {
            InitializeComponent();
            db = DatabaseModel.GetInstance(App.DB_CONNECTION);
        }

        private void saveClick(object sender, EventArgs e)
        {
            var query = from Car c in db.CarTable
                        where c.CarID == ViewModel.ID
                        select c;
            Car car = query.First();
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string carIDStr;
            NavigationContext.QueryString.TryGetValue("id", out carIDStr);
            int.TryParse(carIDStr, out this.carID);
            ViewModel = new CarViewModel(carID);
            ViewModel.PopulateData();
            this.DataContext = ViewModel;
            
            base.OnNavigatedTo(e);
        }

        
        private void DeleteClick(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}