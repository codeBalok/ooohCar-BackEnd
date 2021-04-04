using System;
using System.Collections.Generic;
using System.Text;

namespace CarsbyServices.ViewModel
{
    public class VehicleDetail
    {
        public string VehicleName { get; set; }
        public string city { get; set; }
        public string latitude { get; set; }
        public string logitude { get; set; }
        public List<string> VehileImage { get; set; }
        public decimal? VehiclePrice { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string BodyTypeName { get; set; }
        public string Year { get; set; }
        public string Condition { get; set; }
        public string Transmission { get; set; }
        public string Location { get; set; }
        public string FuelType { get; set; }
        public string KiloMeterDriven { get; set; }
        public string RegistrationNumber { get; set; }
        public string OdoMeter { get; set; }
        public string description { get; set; }
    }

}
