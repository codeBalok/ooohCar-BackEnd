using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class MakeImage
    {
        public int Id { get; set; }
        public int? MakeId { get; set; }
        public string ImageName { get; set; }

        public virtual CarMake Make { get; set; }
    }
}
