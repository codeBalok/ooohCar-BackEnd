using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class VehicleCategory
    {
        public VehicleCategory()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int VehicleCategoryId { get; set; }
        public string VehicleType { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
