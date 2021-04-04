using System;
using System.Collections.Generic;
using System.Text;

namespace CarsbyServices.Interfaces
{
    public interface IVehicleImageRepository
    {
        System.Threading.Tasks.Task<int> SaveVehicleImage(string imagePath, int vehicleId);
    }
}
