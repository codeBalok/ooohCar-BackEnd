using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class CarSpecificationValue
    {
        public int IdCarSpecificationValue { get; set; }
        public int IdCarTrim { get; set; }
        public int IdCarSpecification { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
        public long DateCreate { get; set; }
        public long DateUpdate { get; set; }
        public int IdCarType { get; set; }
        public string Trial132 { get; set; }

        public virtual CarSpecification IdCarSpecificationNavigation { get; set; }
        public virtual CarTrim IdCarTrimNavigation { get; set; }
        public virtual CarType IdCarTypeNavigation { get; set; }
    }
}
