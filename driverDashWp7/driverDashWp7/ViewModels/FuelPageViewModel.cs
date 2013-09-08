using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using driverDashWp7.Models;

namespace driverDashWp7.ViewModels
{
    public class FuelPageViewModel : ViewModelBase
    {
        private SettingsPageViewModel Settings;

        private ObservableCollection<FuelItemViewModel> _fuelList;
        public ObservableCollection<FuelItemViewModel> FuelList
        {
            get
            { return _fuelList; }
            set
            {
                _fuelList = value;
                NotifyPropertyChanged("FuelList");
            }
        }

        private ObservableCollection<ChartsLineDataModel> _fuelChart;
        public ObservableCollection<ChartsLineDataModel> FuelChart
        {
            get
            {
                return _fuelChart;
            }
            set
            {
                _fuelChart = value;
                NotifyPropertyChanged("FuelChart");
            }
        }

        private int _carID;
        public int CarID
        {
            get
            {
                return _carID;
            }
            set
            {
                _carID = value;
                NotifyPropertyChanged("CarID");
            }
        }

        private string _carName;
        public string CarName
        {
            get { return _carName; }
            set
            {
                _carName = value;
                NotifyPropertyChanged("CarName");
            }
        }

        public FuelPageViewModel(int carID)
        {
            Settings = new SettingsPageViewModel();
            DatabaseModel db = DatabaseModel.GetInstance(App.DB_CONNECTION);
            var fuelQuery = from Fuel f in db.FuelTable
                            where f.CarID == carID
                            orderby f.Created descending
                            select f;
            FuelList = new ObservableCollection<FuelItemViewModel>();
            FuelChart = new ObservableCollection<ChartsLineDataModel>();
            CarID = carID;

            var carQuery = from Car c in db.CarTable
                           where c.CarID == CarID
                           select c;
            Car cc = carQuery.First();

            CarName = cc.Year+" "+ cc.Make + " " + cc.Model;
            int preIndex = 0,miles;
            float mpg = 0.0f;
            Fuel[] fuelArray = fuelQuery.ToArray();

            float[] monthlyCost = new float[13];
            int[] monthlyMiles = new int[13];
            float[] monthlyfuel = new float[13]{0.01f,0.01f,0.01f,0.01f,0.01f,0.01f,0.01f,0.01f,0.01f,0.01f,0.01f,0.01f,0.01f};//default cause for milage the division by zero throws a exception

            for(int i = 0;i<fuelArray.Length-1;i++)
            {
                miles =  fuelArray[i].Odometer - fuelArray[i + 1].Odometer;
                mpg = miles / fuelArray[i].FillupVolume;
                FuelList.Add(new FuelItemViewModel { 
                                                    Date = fuelArray[i].Created.ToShortDateString(),
                                                    FuelID = fuelArray[i].FuelID,
                                                    Time = fuelArray[i].Created.ToShortTimeString(),
                                                    MPG = mpg.ToString("F2") + " "+Settings.MPG,
                                                    Miles = miles+" "+Settings.Distance+" driven",
                                                    Vol = fuelArray[i].FillupVolume.ToString("F2") + " "+Settings.Vol,
                                                    Cost = Settings.Currency+" "+fuelArray[i].FillupCost.ToString("F2")
                });

                monthlyCost[fuelArray[i].Created.Month] += fuelArray[i].FillupCost;
                monthlyMiles[fuelArray[i].Created.Month] += miles;
                monthlyfuel[fuelArray[i].Created.Month] += fuelArray[i].FillupVolume;

            }

            FuelList.Add(new FuelItemViewModel
            {
                Date = fuelArray.Last().Created.ToShortDateString(),
                FuelID = fuelArray.Last().FuelID,
                Time = fuelArray.Last().Created.ToShortTimeString(),
                MPG =  "0 "+Settings.MPG,
                Miles = fuelArray.Last().Odometer + " "+Settings.Distance,
                Vol = fuelArray.Last().FillupVolume.ToString("F2") + " "+Settings.Vol,
                Cost = Settings.Currency+" " + fuelArray.Last().FillupCost.ToString("F2")
            });
            monthlyCost[fuelArray.Last().Created.Month] += fuelArray.Last().FillupCost;
            monthlyMiles[fuelArray.Last().Created.Month] += 0;
            monthlyfuel[fuelArray.Last().Created.Month] += fuelArray.Last().FillupVolume;

            //aggregate data for fuelchart
            FuelChart.Add(new ChartsLineDataModel() { Title="jan",Line1=monthlyCost[1],Line2=monthlyfuel[1],Line3=monthlyMiles[1]/monthlyfuel[1] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "feb", Line1 = monthlyCost[2], Line2 = monthlyfuel[2], Line3 = monthlyMiles[2] / monthlyfuel[2] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "mar", Line1 = monthlyCost[3], Line2 = monthlyfuel[3], Line3 = monthlyMiles[3] / monthlyfuel[3] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "apr", Line1 = monthlyCost[4], Line2 = monthlyfuel[4], Line3 = monthlyMiles[4] / monthlyfuel[4] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "may", Line1 = monthlyCost[5], Line2 = monthlyfuel[5], Line3 = monthlyMiles[5] / monthlyfuel[5] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "jun", Line1 = monthlyCost[6], Line2 = monthlyfuel[6], Line3 = monthlyMiles[6] / monthlyfuel[6] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "jul", Line1 = monthlyCost[7], Line2 = monthlyfuel[7], Line3 = monthlyMiles[7] / monthlyfuel[7] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "aug", Line1 = monthlyCost[8], Line2 = monthlyfuel[8], Line3 = (float)(monthlyMiles[8] / monthlyfuel[8]) });
            FuelChart.Add(new ChartsLineDataModel() { Title = "sep", Line1 = monthlyCost[9], Line2 = monthlyfuel[9], Line3 = monthlyMiles[9] / monthlyfuel[9] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "oct", Line1 = monthlyCost[10], Line2 = monthlyfuel[10], Line3 = monthlyMiles[10] / monthlyfuel[10] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "nov", Line1 = monthlyCost[11], Line2 = monthlyfuel[11], Line3 = monthlyMiles[11] / monthlyfuel[11] });
            FuelChart.Add(new ChartsLineDataModel() { Title = "dec", Line1 = monthlyCost[12], Line2 = monthlyfuel[12], Line3 = monthlyMiles[12] / monthlyfuel[12] });
        }

    }
}
