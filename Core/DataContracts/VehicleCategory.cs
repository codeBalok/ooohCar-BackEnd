using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class VehicleCategory
    {
        public VehicleCategory()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int VehicleCategoryId { get; set; }
        public string VehicleType { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
