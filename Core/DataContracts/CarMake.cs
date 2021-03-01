using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class CarMake
    {
        public CarMake()
        {
            CarModels = new HashSet<CarModel>();
            MakeImages = new HashSet<MakeImage>();
        }

        public int IdCarMake { get; set; }
        public string Name { get; set; }
        public long DateCreate { get; set; }
        public long DateUpdate { get; set; }
        public int IdCarType { get; set; }
        public string Trial112 { get; set; }

        public virtual CarType IdCarTypeNavigation { get; set; }
        public virtual ICollection<CarModel> CarModels { get; set; }
        public virtual ICollection<MakeImage> MakeImages { get; set; }
    }
}
