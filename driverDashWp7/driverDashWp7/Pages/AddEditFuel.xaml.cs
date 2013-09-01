using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using driverDashWp7.Models;

namespace driverDashWp7.Pages
{
    public partial class AddEditFuel : PhoneApplicationPage
    {
        private int FueID;
        private Fuel ViewModel;
        private DatabaseModel db;

        public AddEditFuel()
        {
            InitializeComponent();
        }

        private void Menu_save(object sender, EventArgs e)
        {

            db.SubmitChanges();
            if (NavigationService.CanGoBack)
            { NavigationService.GoBack(); }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);
            string fuelID;
            NavigationContext.QueryString.TryGetValue("id", out fuelID);
            FueID = int.Parse(fuelID);
            db = DatabaseModel.GetInstance(App.DB_CONNECTION);

            if (this.FueID > 0)
            {
                var fuelRecord = from Fuel f in db.FuelTable
                                 where f.FuelID == this.FueID
                                 select f;
                ViewModel = fuelRecord.First();
            }
            else
            {
                ViewModel = new Fuel() { Created = DateTime.Now };
            }

            this.DataContext = ViewModel;

        }
               

        private void Menu_delete(object sender, EventArgs e)
        {
            db.FuelTable.DeleteOnSubmit(ViewModel);
            db.SubmitChanges();
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }


    }
}