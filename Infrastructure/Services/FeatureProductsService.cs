using Core.Interfaces;
using CarsbyEF.DataContracts;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class FeatureProductsService : IFeatureProductsRepository
    {
        private readonly CarBuyContext _dBContext;
        public FeatureProductsService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<Vehicle> GetProductsList()
        {
            return _dBContext.Vehicles.Take(6).ToList();
        }
    }
}