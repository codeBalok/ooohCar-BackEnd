using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class WhistList
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public string UserId { get; set; }
        public bool? IsFavourite { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
