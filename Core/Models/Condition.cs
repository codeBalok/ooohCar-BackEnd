﻿using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Condition
    {
        public Condition()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Condition1 { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}