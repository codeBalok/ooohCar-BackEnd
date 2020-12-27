using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Price
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
