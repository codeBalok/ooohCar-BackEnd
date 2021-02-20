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
    public class ImageServiceService :IImageServiceRepository
    {
        private readonly CarBuyContext _dBContext;
        private readonly IImageServiceRepository _searchRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        public ImageServiceService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }

        public string GetImagesByModel(int id)
        {
            return _dBContext.Images.Where(x=> x.ModelId == id).Select(x=> x.Image).FirstOrDefault();
        }
    }
}