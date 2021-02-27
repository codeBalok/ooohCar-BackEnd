using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class CarSpecification
    {
        public CarSpecification()
        {
            CarSpecificationValues = new HashSet<CarSpecificationValue>();
            InverseIdParentNavigation = new HashSet<CarSpecification>();
        }

        public int IdCarSpecification { get; set; }
        public string Name { get; set; }
        public int? IdParent { get; set; }
        public long DateCreate { get; set; }
        public long DateUpdate { get; set; }
        public int IdCarType { get; set; }
        public string Trial132 { get; set; }

        public virtual CarType IdCarTypeNavigation { get; set; }
        public virtual CarSpecification IdParentNavigation { get; set; }
        public virtual ICollection<CarSpecificationValue> CarSpecificationValues { get; set; }
        public virtual ICollection<CarSpecification> InverseIdParentNavigation { get; set; }
    }
}
