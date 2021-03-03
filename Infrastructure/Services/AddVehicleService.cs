using CarsbyEF.DataContracts;
using CarsbyServices.Interfaces;
using CarsbyServices.ViewModels;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsbyServices.Services
{
    public class AddVehicleService : IAddVehicleRepository
    {

        private readonly CarBuyContext _dBContext;
      
        public AddVehicleService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
            
        }

        
        public async Task<List<getmakeList>> GetMakeListForAddVehicleAsync()
        {
            return await _dBContext.CarMakes.Select(x => new getmakeList
            {
                Id = x.IdCarMake,
                Name = x.Name,
                LogoImages = x.MakeImages.FirstOrDefault().ImageName
            }).ToListAsync();
        }

        public async Task<List<getmodelList>> GetModelListAsync(int makeId)
        {
            return await _dBContext.CarModels.Where(x => x.IdCarMake ==makeId).Select(x => new getmodelList
            {
                Id = x.IdCarModel,
                Name = x.Name,
                
            }).ToListAsync();
        }


    }
}
