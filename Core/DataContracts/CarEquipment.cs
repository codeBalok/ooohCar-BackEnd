using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class CarEquipment
    {
        public CarEquipment()
        {
            CarOptionValues = new HashSet<CarOptionValue>();
        }

        public int IdCarEquipment { get; set; }
        public int IdCarTrim { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public long DateCreate { get; set; }
        public long DateUpdate { get; set; }
        public int IdCarType { get; set; }
        public string Trial109 { get; set; }

        public virtual CarType IdCarTypeNavigation { get; set; }
        public virtual ICollection<CarOptionValue> CarOptionValues { get; set; }
    }
}
