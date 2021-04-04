using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class Variant
    {
        public int Id { get; set; }
        public string Varient { get; set; }
        public int? ModelId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? Popular { get; set; }

        public virtual Model Model { get; set; }
    }
}
