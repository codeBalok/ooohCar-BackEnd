﻿using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Colour
    {
        public Colour()
        {
            ModelColour = new HashSet<ModelColour>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<ModelColour> ModelColour { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
