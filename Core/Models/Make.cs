using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Make
    {
        public Make()
        {
            Model = new HashSet<Model>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoImage { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Model> Model { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
