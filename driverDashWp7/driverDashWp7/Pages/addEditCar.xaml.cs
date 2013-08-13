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

        public AddEditCar()
        {
            InitializeComponent();
        }

        private void saveClick(object sender, EventArgs e)
        {
            if (carID == 0)
            {
                addCar();
            }
            else
            {
                updateCar();
            }
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void addCar()
        {
           
        }

        private void updateCar()
        {
            if (txtMake.Text.Length > 0)
            {
           
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