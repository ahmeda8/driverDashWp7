using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using driverDashWp7.ViewModels;

namespace driverDashWp7.Models
{
    public class DatabaseModel : DataContext
    {
        private static DatabaseModel _instance = null;

        public static DatabaseModel GetInstance(string connectionString)
        {
            if (_instance == null)
                _instance = new DatabaseModel(connectionString);
            
            return _instance;
        }

        public DatabaseModel(string connectionString) : base(connectionString)
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
#if DEBUG
                //if debug then fill some test information after db creation
                this.CarTable.InsertOnSubmit(new Car { Make="BMW", Model="328i", Year="2013", License="8SXY443", Vin="asda2342", Insurance="sds233" });
                this.CarTable.InsertOnSubmit(new Car { Make = "Mercedez", Model = "C350", Year = "2013", License = "8BMB007", Vin = "asda2342", Insurance = "sds233" });
                this.CarTable.InsertOnSubmit(new Car { Make = "Audi", Model = "A4", Year = "2013", License = "4DMB747", Vin = "asda2342", Insurance = "sds233" });
                SubmitChanges();

                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 1, Created = DateTime.Parse("06/01/2013"), FillupCost = 45.54f, FillupVolume = 14.54f, Odometer = 100 });
                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 1, Created = DateTime.Parse("07/07/2013"), FillupCost = 45.54f, FillupVolume = 18.54f, Odometer = 300 });
                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 1, Created = DateTime.Parse("08/14/2013"), FillupCost = 50.54f, FillupVolume = 10.40f, Odometer = 500 });
                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 1, Created = DateTime.Parse("08/20/2013"), FillupCost = 90.54f, FillupVolume = 12.24f, Odometer = 700 });

                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 2, Created = DateTime.Parse("06/01/2013"), FillupCost = 40.54f, FillupVolume = 14.54f, Odometer = 100 });
                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 2, Created = DateTime.Parse("07/07/2013"), FillupCost = 30.54f, FillupVolume = 28.54f, Odometer = 400 });
                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 2, Created = DateTime.Parse("07/14/2013"), FillupCost = 25.54f, FillupVolume = 15.40f, Odometer = 500 });
                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 2, Created = DateTime.Parse("08/20/2013"), FillupCost = 45.54f, FillupVolume = 9.24f, Odometer = 800 });

                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 3, Created = DateTime.Parse("06/01/2013"), FillupCost = 24.54f, FillupVolume = 14.54f, Odometer = 1000 });
                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 3, Created = DateTime.Parse("07/07/2013"), FillupCost = 65.54f, FillupVolume = 10.54f, Odometer = 2500 });
                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 3, Created = DateTime.Parse("08/14/2013"), FillupCost = 78.54f, FillupVolume = 16.4f, Odometer = 5000 });
                this.FuelTable.InsertOnSubmit(new Fuel { CarID = 3, Created = DateTime.Parse("08/20/2013"), FillupCost = 25.54f, FillupVolume = 18.24f, Odometer = 6504 });

                SubmitChanges();
#endif
            }
        }

        public Table<Car> CarTable;
        public Table<Fuel> FuelTable;
        public Table<maintInfo> MaintTable;
        public Table<reminderInfo> reminderInfo;
    }

    #region Table and class for car info

    [Table]
    public class Car : ViewModelBase
    {
        private int _carid;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int CarID
        {
            get { return _carid; }
            set { _carid = value; NotifyPropertyChanged("CarID"); } 
        }

        private string _make;
        [Column]
        public string Make
        { get { return _make; } 
            set { _make = value; NotifyPropertyChanged("Make"); } }

        private string _model;
        [Column]
        public string Model
        { get { return _model; } set { _model = value; NotifyPropertyChanged("Model"); } }

        private string _year;
        [Column]
        public string Year
        { get { return _year; } set { _year = value; NotifyPropertyChanged("Year"); } }

        private string _license;
        [Column]
        public string License { get { return _license; } set { _license = value; NotifyPropertyChanged("License"); } }

        private string _vin;
        [Column]
        public string Vin { get { return _vin; } set { _vin = value; NotifyPropertyChanged("Vin"); } }

        private string _insurance;
        [Column]
        public string Insurance { get { return _insurance; } set { _insurance = value; NotifyPropertyChanged("Insurance"); } }

        private int _vehtype;
        [Column]
        public int VehicleType { get { return _vehtype; } set { _vehtype = value; NotifyPropertyChanged("VehicleType"); } }
    }
#endregion

    #region Table and class for fuel info
    [Table]

    public class Fuel
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int FuelID { get; set; }

        [Column]
        public int CarID { get; set; }

        [Column]
        public DateTime Created { get; set; }

        [Column]
        public int Odometer { get; set; }

        [Column]
        public float FillupVolume { get; set; }

        [Column]
        public float FillupCost { get; set; }
    }
#endregion

    #region Table and class for maint info
    [Table]
    public class maintInfo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int MaintID { get; set; }

        [Column]
        public int CarID { get; set; }

        [Column]
        public DateTime Created { get; set; }

        [Column]
        public string MaintType { get; set; }
        
        [Column]
        public string PartName { get; set; }

        [Column]
        public string PartNumber { get; set; }

        [Column]
        public float PartCost { get; set; }

        [Column]
        public float LaborCharges { get; set; }

        [Column]
        public int Odometer { get; set; }
    }

    #endregion

    #region Table for reminder
    [Table]

    public class reminderInfo : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _reminderID;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ReminderID
        {
            get { return _reminderID; }
            set
            {
                if (_reminderID != value)
                {
                    NotifyPropertyChanging("ReminderID");
                    _reminderID = value;
                    NotifyPropertyChanged("ReminderID");
                }
            }
        }

        private int _carID;
        [Column]
        public int CarID
        {
            get { return _carID; }
            set
            {
                if (_carID != value)
                {
                    NotifyPropertyChanging("CarID");
                    _carID = value;
                    NotifyPropertyChanged("CarID");
                }
            }
        }

        private DateTime _date;
        [Column]
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if(_date != value)
                {
                     NotifyPropertyChanging("Date");
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
                }
            }

        private int _dueMiles;
        [Column]
        public int DueMiles
        {
            get { return _dueMiles; }
            set
            {
                if(_dueMiles != value)
                {
                     NotifyPropertyChanging("DueMiles");
                    _dueMiles = value;
                    NotifyPropertyChanged("DueMiles");
                }
                
            }
        }
         private string _item;
        [Column]
        public string Item
        {
            get { return _item; }
            set
            {
                if(_item != value)
                {
                     NotifyPropertyChanging("Item");
                    _item = value;
                    NotifyPropertyChanged("Item");
                }
                
            }
        }
        private string _desc;
        [Column]
        public string Desc
        {
            get { return _desc; }
            set
            {
                if (_desc != value)
                {
                    NotifyPropertyChanging("Desc");
                    _desc = value;
                    NotifyPropertyChanged("Desc");
                }

            }
        }

        private string _dateStr;

        [Column]
        public string DateStr
        {
            get { return _dateStr; }
            set
            {
                if (_dateStr != value)
                {
                    NotifyPropertyChanging("DateStr");
                    _dateStr = value;
                    NotifyPropertyChanged("DateStr");
                }
            }
        }
        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

}
        
 
    
#endregion

}
