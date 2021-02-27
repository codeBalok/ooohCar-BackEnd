using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class Model
    {
        public Model()
        {
            Images = new HashSet<Image>();
            ModelColours = new HashSet<ModelColour>();
            Variants = new HashSet<Variant>();
            Vehicles = new HashSet<Vehicle>();
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
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<ModelColour> ModelColours { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
