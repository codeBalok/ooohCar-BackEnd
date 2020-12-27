using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Details
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string VehicaleId { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
