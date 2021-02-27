using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class CarGeneration
    {
        public CarGeneration()
        {
            CarSeries = new HashSet<CarSerie>();
        }

        public int IdCarGeneration { get; set; }
        public int IdCarModel { get; set; }
        public string Name { get; set; }
        public string YearBegin { get; set; }
        public string YearEnd { get; set; }
        public long DateCreate { get; set; }
        public long DateUpdate { get; set; }
        public int IdCarType { get; set; }
        public string Trial112 { get; set; }

        public virtual CarModel IdCarModelNavigation { get; set; }
        public virtual CarType IdCarTypeNavigation { get; set; }
        public virtual ICollection<CarSerie> CarSeries { get; set; }
    }
}
