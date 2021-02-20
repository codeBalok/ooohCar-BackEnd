﻿using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Model
    {
        public Model()
        {
            Images = new HashSet<Images>();
            ModelColour = new HashSet<ModelColour>();
            Variant = new HashSet<Variant>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int YearId { get; set; }
        public int MakeId { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? Popular { get; set; }

        public virtual Make Make { get; set; }
        public virtual Year Year { get; set; }
        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<ModelColour> ModelColour { get; set; }
        public virtual ICollection<Variant> Variant { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
