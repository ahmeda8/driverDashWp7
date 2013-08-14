using System;
using System.Linq;
using Microsoft.Phone.Controls;
using System.Windows;
using driverDashWp7.ViewModels;
using driverDashWp7.Models;

namespace driverDashWp7.Pages
{
    public partial class AddEditCar : PhoneApplicationPage
    {
        private int carID;
        private Car ViewModel;
        private DatabaseModel db;

        public AddEditCar()
        {
            InitializeComponent();
            db = DatabaseModel.GetInstance(App.DB_CONNECTION);
        }

        private void saveClick(object sender, EventArgs e)
        {
            if (carID == 0)
                db.CarTable.InsertOnSubmit(ViewModel);
            db.SubmitChanges();
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
            var query = from Car c in db.CarTable
                        where c.CarID == carID
                        select c;
            if (carID == 0)
                ViewModel = new Car();
            else
                ViewModel = query.First();
            this.DataContext = ViewModel;
            
            base.OnNavigatedTo(e);
        }

        
        private void DeleteClick(object sender, EventArgs e)
        {
            db.CarTable.DeleteOnSubmit(ViewModel);
            db.SubmitChanges();
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}