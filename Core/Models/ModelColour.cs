using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class ModelColour
    {
        public int Id { get; set; }
        public int? ModelId { get; set; }
        public int? ColourId { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Colour Colour { get; set; }
        public virtual Model Model { get; set; }
    }
}
