using CarsbyEF.DataContracts;
using CarsbyServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsbyServices.Interfaces
{
    public interface ICarDetailRepository
    {
        System.Threading.Tasks.Task<Vehicle> GetVehicleDetailbyIdAsync(int vehicleId);
        System.Threading.Tasks.Task<List<string>> getVehcileImages(int? imageId);
        System.Threading.Tasks.Task<string> getMake(int? makeid);
        System.Threading.Tasks.Task<string> getModel(int? modelid);
        System.Threading.Tasks.Task<string> getBodyTypeName(int? id);
        System.Threading.Tasks.Task<string> getYearName(int? id);
        System.Threading.Tasks.Task<string> getConditioName(int? id);
        System.Threading.Tasks.Task<string> getTransmissionName(int? id);
        System.Threading.Tasks.Task<string> GetFualTypeName(int? id);
    }
}
