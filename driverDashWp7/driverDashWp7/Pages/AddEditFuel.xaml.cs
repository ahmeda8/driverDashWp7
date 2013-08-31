using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace driverDashWp7.Pages
{
    public partial class AddEditFuel : PhoneApplicationPage
    {
        public AddEditFuel()
        {
            InitializeComponent();
        }

        private void Menu_save(object sender, EventArgs e)
        {
            
            if (NavigationService.CanGoBack)
            { NavigationService.GoBack(); }
        }

        private bool addFuelRecord()
        {
            
            MessageBox.Show("Incomplete or Incorrect data");
            return false; 
            
        }

        private bool UpdateFuelRecord()
        {
            return true;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);
        }
               

        private void Menu_delete(object sender, EventArgs e)
        {
            
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }


    }
}