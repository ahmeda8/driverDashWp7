using System;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Controls;
using System.Windows;
using driverDashWp7.ViewModels;

namespace driverDashWp7.Pages
{
    public partial class Settings : PhoneApplicationPage
    {
        private SettingsPageViewModel ViewModel;
        public Settings()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Settings_Loaded);
        }

        void Settings_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel = new SettingsPageViewModel();
            this.DataContext = ViewModel;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}