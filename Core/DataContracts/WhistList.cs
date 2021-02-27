using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class WhistList
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public string UserId { get; set; }
        public bool? IsFavourite { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
