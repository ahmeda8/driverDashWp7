using System;
using System.Collections.ObjectModel;
using driverDashWp7.Models;

namespace driverDashWp7.ViewModels
{
    public class CarViewModel : ViewModelBase
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("ID");
            }
        }

        private string _year;
        public string Year
        {
            get { return _year; }
            set
            {
                _year = value;
                NotifyPropertyChanged("Year");
            }
        }

        private string _make;
        public string Make
        {
            get { return _make; }
            set
            {
                _make = value;
                NotifyPropertyChanged("Make");
            }
        }

        private string _model;
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                NotifyPropertyChanged("Model");
            }
        }

        private string _lic;
        public string Lic
        {
            get { return _lic; }
            set
            {
                _lic = value;
                NotifyPropertyChanged("Lic");
            }
        }

        private ObservableCollection<ChartsPieDataModel> _fuelPieData;
        public ObservableCollection<ChartsPieDataModel> FuelPieData
        {
            get { return _fuelPieData; }
            set
            {
                _fuelPieData = value;
                NotifyPropertyChanged("FuelPieData");
            }
        }

        private ObservableCollection<ChartsPieDataModel> _upkeepPieData;
        public ObservableCollection<ChartsPieDataModel> UpkeepPieData
        {
            get { return _upkeepPieData; }
            set
            {
                _upkeepPieData = value;
                NotifyPropertyChanged("UpkeepPieData");
            }
        }

        public CarViewModel()
        {
            FuelPieData = new ObservableCollection<ChartsPieDataModel>();
            UpkeepPieData = new ObservableCollection<ChartsPieDataModel>();
#if DEBUG
            FuelPieData.Add(new ChartsPieDataModel { Title = "fuel1", Value = 10.0d });
            FuelPieData.Add(new ChartsPieDataModel { Title = "fuel2", Value = 20.0d });
            FuelPieData.Add(new ChartsPieDataModel { Title = "fuel3", Value = 15.0d });

            UpkeepPieData.Add(new ChartsPieDataModel { Title = "upkeep1", Value = 5.0d });
            UpkeepPieData.Add(new ChartsPieDataModel { Title = "upkeep2", Value = 15.0d });
            UpkeepPieData.Add(new ChartsPieDataModel { Title = "upkeep3", Value = 35.0d });
#endif
        }

    }
}
