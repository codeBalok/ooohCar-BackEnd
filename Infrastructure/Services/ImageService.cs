using Core.Interfaces;
using CarsbyEF.DataContracts;
using System.Linq;

namespace Infrastructure.Services
{
    public class ImageServiceService : IImageServiceRepository
    {
        private readonly CarBuyContext _dBContext;

        public ImageServiceService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }

        public string GetImagesByModel(int id)
        {
            return _dBContext.Images.Where(x => x.ModelId == id).Select(x => x.Image1).FirstOrDefault();
        }
    }
}