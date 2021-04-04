using CarsbyEF.DataContracts;
using CarsbyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsbyServices.Services
{
    public class VechicleImageService : IVehicleImageRepository
    {
        private readonly CarBuyContext _dBContext;
        public VechicleImageService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<int> SaveVehicleImage(string imagePath, int vehicleId)
        {
            VehicleImage objSave = new VehicleImage();
            objSave.Image = imagePath;
            objSave.IsActive = true;
            objSave.CreatedDate = DateTime.Now;
            objSave.CreatedBy = 1;
            objSave.VehicleId = vehicleId;
            await _dBContext.VehicleImages.AddAsync(objSave);
            _dBContext.SaveChanges();
            return objSave.Id;
        }
    }

}
