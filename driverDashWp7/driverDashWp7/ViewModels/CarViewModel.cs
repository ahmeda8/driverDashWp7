using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using driverDashWp7.Models;
using System.Linq;
using System.Globalization;

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

        private string _vin;
        public string Vin
        {
            get { return _vin; }
            set
            {
                _vin = value;
                NotifyPropertyChanged("Vin");
            }
        }

        private string _insurance;
        public string Insurance
        {
            get { return _insurance; }
            set
            {
                _insurance = value;
                NotifyPropertyChanged("Lic");
            }
        }

        private bool _IsNewRecord;
        public bool IsNewRecord
        {
            get { return _IsNewRecord; }
            set {
                _IsNewRecord = value;
                NotifyPropertyChanged("IsNewRecord");
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

        private DatabaseModel db;

        public CarViewModel(int carID)
        {
            this.ID = carID;
            db = DatabaseModel.GetInstance(App.DB_CONNECTION);
            FuelPieData = new ObservableCollection<ChartsPieDataModel>();
            UpkeepPieData = new ObservableCollection<ChartsPieDataModel>();

            var fuelPieDataQuery = from Fuel f in db.FuelTable
                                   where f.CarID == this.ID
                                   select f;
            Dictionary<string, float> fuelMonthAggregate = new Dictionary<string, float>();
            foreach (Fuel f in fuelPieDataQuery.ToArray())
            {
                string key = f.Created.ToString("MMM", CultureInfo.CurrentCulture.DateTimeFormat);
                if (fuelMonthAggregate.ContainsKey(key))
                {
                    fuelMonthAggregate[key] += f.FillupCost;
                }
                else
                {
                    fuelMonthAggregate.Add(key, f.FillupCost);
                }
            }

            foreach (KeyValuePair<string, float> agg in fuelMonthAggregate)
            {
                FuelPieData.Add(new ChartsPieDataModel { Title = agg.Key, Value = agg.Value });
            }

            
#if DEBUG
            
            UpkeepPieData.Add(new ChartsPieDataModel { Title = "upkeep1", Value = 5.0d });
            UpkeepPieData.Add(new ChartsPieDataModel { Title = "upkeep2", Value = 15.0d });
            UpkeepPieData.Add(new ChartsPieDataModel { Title = "upkeep3", Value = 35.0d });
#endif
        }

        public void PopulateData()
        {
            if (this.ID > 0)
            {
                var query = from Car c in db.CarTable
                            where c.CarID == this.ID
                            select c;
                Car car = query.First();
                Make = car.Make;
                Model = car.Model;
                Lic = car.License;
                Year = car.Year;
                Vin = car.Vin;
                Insurance = car.Insurance;
            }
        }

    }
}
