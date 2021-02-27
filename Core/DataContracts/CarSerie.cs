using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class CarSerie
    {
        public CarSerie()
        {
            CarTrims = new HashSet<CarTrim>();
        }

        public int IdCarSerie { get; set; }
        public int IdCarModel { get; set; }
        public int? IdCarGeneration { get; set; }
        public string Name { get; set; }
        public long DateCreate { get; set; }
        public long DateUpdate { get; set; }
        public int IdCarType { get; set; }
        public string Trial129 { get; set; }

        public virtual CarGeneration IdCarGenerationNavigation { get; set; }
        public virtual CarModel IdCarModelNavigation { get; set; }
        public virtual CarType IdCarTypeNavigation { get; set; }
        public virtual ICollection<CarTrim> CarTrims { get; set; }
    }
}
