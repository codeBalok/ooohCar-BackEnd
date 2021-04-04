using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class Make
    {
        public Make()
        {
            Models = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoImage { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
