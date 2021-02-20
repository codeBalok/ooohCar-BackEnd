using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class WhistListDto
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public string UserId { get; set; }
        public bool IsFavourite { get; set; }
    }
}
