using CarsbyEF.DataContracts;
using CarsbyServices.Interfaces;
using CarsbyServices.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsbyServices.ViewModel;

namespace CarsbyServices.Services
{
    public class CarDetailService : ICarDetailRepository
    {
        private readonly CarBuyContext _dBContext;

        public CarDetailService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
            //_mapper = mapper;
        }

        public async Task<Vehicle> GetVehicleDetailbyIdAsync(int vehicleId)
        {
            var Vehicles = await _dBContext.Vehicles.Where(x => x.Id == vehicleId).FirstOrDefaultAsync();
            return Vehicles;


        }
        public async Task<List<string>> getVehcileImages(int? vehicleId)
        {
            List<string> objVEchileImages = new List<string>();
            try
            {
                var vehicleImages = await _dBContext.VehicleImages.Where(x => x.VehicleId == vehicleId).ToListAsync();
                foreach (var vechileImage in vehicleImages)
                {
                    objVEchileImages.Add(vechileImage.Image);
                }
            }
            catch (Exception ex)
            {

            }
            return objVEchileImages;
        }
        public async Task<string> getMake(int? makeid)
        {
            try
            {
                if (makeid > 0)
                {
                    var Make = await _dBContext.CarMakes.Where(x => x.IdCarMake == makeid).FirstOrDefaultAsync();
                    return Make.Name;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> getModel(int? modelid)
        {
            try
            {
                if (modelid > 0)
                {
                    var model = await _dBContext.CarModels.Where(x => x.IdCarMake == modelid).FirstOrDefaultAsync();
                    return model.Name;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> getBodyTypeName(int? id)
        {
            try
            {
                if (id > 0)
                {
                    var bodytype = await _dBContext.BodyTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
                    return bodytype.Name;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<string> getYearName(int? id)
        {
            try
            {
                if (id > 0)
                {
                    var year = await _dBContext.Years.Where(x => x.Id == id).FirstOrDefaultAsync();
                    return year.Name;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<string> getConditioName(int? id)
        {
            try
            {
                if (id > 0)
                {
                    var condition = await _dBContext.Conditions.Where(x => x.Id == id).FirstOrDefaultAsync();
                    return condition.Condition1;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<string> getTransmissionName(int? id)
        {
            try
            {
                if (id > 0)
                {
                    var transmission = await _dBContext.Transmissions.Where(x => x.Id == id).FirstOrDefaultAsync();
                    return transmission.Name;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<string> GetFualTypeName(int? id)
        {
            try
            {
                if (id > 0)
                {
                    var fualtype = await _dBContext.FuelTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
                    return fualtype.Name;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
