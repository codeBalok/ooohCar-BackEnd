using Core.Interfaces;
using CarsbyEF.DataContracts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarsbyServices.Services
{
    public class ImageServiceService : IImageServiceRepository
    {
        private readonly CarBuyContext _dBContext;

        public ImageServiceService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async System.Threading.Tasks.Task<string> GetImagesByModelAsync(int id)
        {
            return await _dBContext.Images.Where(x => x.ModelId == id).Select(x => x.Image1).FirstOrDefaultAsync();
        }
    }
}