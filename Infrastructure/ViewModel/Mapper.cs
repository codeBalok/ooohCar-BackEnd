using CarsbyEF.DataContracts;
using CarsbyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsbyServices.ViewModel
{
    public class Mapper
    {
        private readonly ICarDetailRepository _vehicleDetailrepo;
        public Mapper(ICarDetailRepository vechileDetailrepo)
        {
            _vehicleDetailrepo = vechileDetailrepo;

        }
        public async Task<VehicleDetail> MapVehicleDetailWithVehicleDetail(Vehicle Vehicle)
        {
            if (Vehicle == null)
                return null;
            return new VehicleDetail
            {
                VehicleName = Vehicle.Name,
                city = Vehicle.City,
                latitude = Vehicle.Latitude,
                logitude = Vehicle.Longitude,
                VehileImage = await _vehicleDetailrepo.getVehcileImages(Vehicle.Id),
                MakeName = await _vehicleDetailrepo.getMake(Vehicle.MakeId),
                ModelName = await _vehicleDetailrepo.getModel(Vehicle.ModelId),
                VehiclePrice = Vehicle.Price,
                BodyTypeName = await _vehicleDetailrepo.getBodyTypeName(Vehicle.BodyTypeId),
                Year = await _vehicleDetailrepo.getYearName(Vehicle.YearId),
                Condition = await _vehicleDetailrepo.getConditioName(Vehicle.ConditionId),
                Transmission = await _vehicleDetailrepo.getTransmissionName(Vehicle.TransmissionId),
                FuelType = await _vehicleDetailrepo.GetFualTypeName(Vehicle.FuelTypeId),
                KiloMeterDriven = Vehicle.Kilometer.ToString(),
                Location = Vehicle.City,
                OdoMeter = Vehicle.Odometers,
                RegistrationNumber = Vehicle.RegistrationPlate,
                description = Vehicle.Description
            };
        }

    }
}
