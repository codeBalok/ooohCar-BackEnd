using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class InductionTurbo
    {
        public InductionTurbo()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
