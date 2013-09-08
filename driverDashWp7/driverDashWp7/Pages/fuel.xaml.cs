using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using driverDashWp7.ViewModels;

namespace driverDashWp7.Pages
{
    public partial class fuel : PhoneApplicationPage
    {
        private FuelPageViewModel ViewModel;
        public fuel()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string carID;
            NavigationContext.QueryString.TryGetValue("id", out carID);
            ViewModel = new FuelPageViewModel(int.Parse(carID));
            this.DataContext = ViewModel;
        }

        private void add_new_fuel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AddEditFuel.xaml?id=0&carid="+ViewModel.CarID,UriKind.Relative));
        }

        private void Edit_fuel_click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string id = b.Tag.ToString() ;
            NavigationService.Navigate(new Uri("/Pages/AddEditFuel.xaml?id="+id+"&carid="+ViewModel.CarID, UriKind.Relative));
        }
    }
}