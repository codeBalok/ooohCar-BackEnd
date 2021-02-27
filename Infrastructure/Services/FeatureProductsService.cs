using Core.Interfaces;
using CarsbyEF.DataContracts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CarsbyServices.ViewModels;
using System.Threading.Tasks;

namespace CarsbyServices.Services
{
    public class FeatureProductsService : IFeatureProductsRepository
    {
        private readonly CarBuyContext _dBContext;
        private readonly IImageServiceRepository _imageServiceRepository;
        private readonly ISearchRepository _searchRepository;
        public FeatureProductsService(CarBuyContext dBContext,
         IImageServiceRepository imageServiceRepository, ISearchRepository searchRepository)
        {
            _dBContext = dBContext;
            _searchRepository = searchRepository;
            _imageServiceRepository = imageServiceRepository;
        }

        public async Task<List<VehicleViewModel>> GetProductsListAsync()
        {
            var vechcles = await _dBContext.Vehicles.ToListAsync();
            List<VehicleViewModel> vehicleViewModel = new List<VehicleViewModel>();
            foreach (var x in vechcles)
            {
                vehicleViewModel.Add(new VehicleViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Odometers = x.Odometers,
                    RegistrationPlate = x.RegistrationPlate,
                    Vin = x.Vin,
                    Image = await _imageServiceRepository.GetImagesByModelAsync(x.ModelId ?? 0),
                    Year = _searchRepository.GetYear(x.ModelId ?? 0),
                    Body = _searchRepository.GetBody(x.BodyTypeId),
                    FuelType = _searchRepository.GetFuelType(x.FuelTypeId ?? 0),
                    Transmission = _searchRepository.GetTransmission(x.TransmissionId ?? 0),
                    Cylinders = _searchRepository.GetCylinders(x.CylindersId ?? 0),
                    Type = _searchRepository.GetType(x.VehicalTypeId ?? 0),

                });
            }

            return vehicleViewModel;
        }
    }
}