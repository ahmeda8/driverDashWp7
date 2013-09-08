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
    public partial class MainPage : PhoneApplicationPage
    {
        MainPageViewModel ViewModel;        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void add_vehicle(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/addEditCar.xaml?id=0", UriKind.Relative));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel = new MainPageViewModel();
            this.DataContext = ViewModel;
        }

        private void edit_car_click(object sender, RoutedEventArgs e)
        {
            string carid;
            Button b = sender as Button;
            carid = b.Tag.ToString();
            NavigationService.Navigate(new Uri("/Pages/addEditCar.xaml?id="+carid, UriKind.Relative));
        }

        private void edit_maint_click(object sender, RoutedEventArgs e)
        {
            string carid;
            Button b = sender as Button;
            carid = b.Tag.ToString();
            NavigationService.Navigate(new Uri("/Pages/maint.xaml?id=" + carid, UriKind.Relative));
        }

        private void edit_fuel_click(object sender, RoutedEventArgs e)
        {
            string carid;
            Button b = sender as Button;
            carid = b.Tag.ToString();
            NavigationService.Navigate(new Uri("/Pages/fuel.xaml?id=" + carid, UriKind.Relative));
        }

        private void settings_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Settings.xaml", UriKind.Relative));
        }
    }
}