using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class CarOptionValue
    {
        public int IdCarOptionValue { get; set; }
        public int IdCarOption { get; set; }
        public int IdCarEquipment { get; set; }
        public short IsBase { get; set; }
        public long DateCreate { get; set; }
        public long DateUpdate { get; set; }
        public int IdCarType { get; set; }
        public string Trial122 { get; set; }

        public virtual CarEquipment IdCarEquipmentNavigation { get; set; }
        public virtual CarOption IdCarOptionNavigation { get; set; }
        public virtual CarType IdCarTypeNavigation { get; set; }
    }
}
