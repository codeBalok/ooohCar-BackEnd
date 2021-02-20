using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class FeatureProductsService :IFeatureProductsRepository
    {
        private readonly CarBuyContext _dBContext;
        private readonly IFeatureProductsRepository _searchRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        public FeatureProductsService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<Vehicle> GetProductsList()
        {
            return _dBContext.Vehicle.Take(6).ToList();
        }
    }
}