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

        public async Task<List<ConditionViewModel>> GetConditionListAsync()
        {
            return await _dBContext.Conditions.Select(x => new ConditionViewModel
            {
                Id = x.Id,
                Condition = x.Condition1,

            }).ToListAsync();
        }

        public async Task<List<SideSearchCommonViewModel>> GetFuelTypesListAsync()
        {
            var fuelTypes = await _dBContext.FuelTypes.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in fuelTypes)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,

                });
            }
            return sideSearchCommonViewModels;
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
            return await _dBContext.CarModels.Where(x => x.IdCarMake == makeId).Select(x => new getmodelList
            {
                Id = x.IdCarModel,
                Name = x.Name,

            }).ToListAsync();
        }

        public async Task<List<PriceViewModel>> GetPriceListAsync()
        {
            return await _dBContext.Prices.Select(x => new PriceViewModel
            {
                Id = x.Id,
                Price = x.Amount,

            }).ToListAsync();
        }

        public async Task<List<getvarientList>> GetVarientListAsync(int modelid)
        {
            return await _dBContext.CarTrims.Where(x => x.IdCarModel == modelid).Select(x => new getvarientList
            {
                Id = x.IdCarTrim,
                Name = x.Name,

            }).ToListAsync();
        }

        public async Task<List<SideSearchCommonViewModel>> GetYearListAsync()
        {
            return await _dBContext.Years.Select(x => new SideSearchCommonViewModel
            {
                Id = x.Id,
                Name = x.Name,

            }).ToListAsync();
        }


        public async Task<List<SideSearchCommonViewModel>> GetTrasmissionListAsync()
        {
            return await _dBContext.Transmissions.Select(x => new SideSearchCommonViewModel
            {
                Id = x.Id,
                Name = x.Name,

            }).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetColourListAsync()
        {
            var colours = await _dBContext.Colours.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in colours)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetCylindersListAsync()
        {
            var cylinders = await _dBContext.Cylinders.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in cylinders)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,

                });
            }
            return sideSearchCommonViewModels;
        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetBodyTypeListAsync()
        {

            var bodyTypes = await _dBContext.BodyTypes.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in bodyTypes)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,

                });
            }
            return sideSearchCommonViewModels;
        }

        public async Task<string> AddUpdateNewVehicleAsync(Vehicle objvehicleToSave)
        {
            if (objvehicleToSave != null)
            {
                if (objvehicleToSave.Id == 0)
                {
                    await _dBContext.Vehicles.AddAsync(objvehicleToSave);
                    _dBContext.SaveChanges();
                    return "added";
                }
                else
                {
                    _dBContext.Vehicles.Where(a => a.Id == objvehicleToSave.Id).FirstOrDefault();
                    _dBContext.Vehicles.Update(objvehicleToSave);
                    _dBContext.SaveChanges();
                    return "updated";
                }
            }
            else
            {
                return null;
            }
        }
    }
}
