using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class CarModel
    {
        public CarModel()
        {
            CarGenerations = new HashSet<CarGeneration>();
            CarSeries = new HashSet<CarSerie>();
            CarTrims = new HashSet<CarTrim>();
        }

        public int IdCarModel { get; set; }
        public int IdCarMake { get; set; }
        public string Name { get; set; }
        public long DateCreate { get; set; }
        public long DateUpdate { get; set; }
        public int IdCarType { get; set; }
        public string Trial116 { get; set; }

        public virtual CarMake IdCarMakeNavigation { get; set; }
        public virtual CarType IdCarTypeNavigation { get; set; }
        public virtual ICollection<CarGeneration> CarGenerations { get; set; }
        public virtual ICollection<CarSerie> CarSeries { get; set; }
        public virtual ICollection<CarTrim> CarTrims { get; set; }
    }
}
