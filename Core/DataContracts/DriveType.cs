﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CarsbyEF.DataContracts
{
    public partial class DriveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
