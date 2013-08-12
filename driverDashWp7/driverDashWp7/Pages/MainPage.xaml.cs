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
            ViewModel = new MainPageViewModel();
            this.DataContext = ViewModel;
        }
    }
}