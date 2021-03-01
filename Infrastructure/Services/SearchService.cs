using Core.Interfaces;
using CarsbyEF.DataContracts;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CarsbyServices.ViewModels;
using Core.Common;
using System.Threading.Tasks;

namespace CarsbyServices.Services
{
    public class SearchService : ISearchRepository
    {
        private readonly CarBuyContext _dBContext;
        private readonly IImageServiceRepository _imageServiceRepository;
        private readonly IWhistListRepository _whistlistrepo;
        public SearchService(CarBuyContext dBContext, IImageServiceRepository imageServiceRepository, IWhistListRepository whistlistrepo)
        {
            _dBContext = dBContext;
            _imageServiceRepository = imageServiceRepository;
            _whistlistrepo = whistlistrepo;
        }

        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetLocationListAsync()
        {
            return await _dBContext.Locations.Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<getmakeList>> GetMakeListAsync()
        {
            string currentpath = System.IO.Directory.GetCurrentDirectory();
            return await _dBContext.Makes.Select(x => new getmakeList
            {
                Id = x.Id,
                Name = x.Name,
                LogoImages = Utility.ByteToBase64(currentpath + x.LogoImage)
            }).ToListAsync();
        }

       

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetSideSearchMakeListAsync()
        {
            var makeList = await _dBContext.Makes.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in makeList)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByMakeIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }

        public async System.Threading.Tasks.Task<List<Model>> GetModalListCountByIDAsync(int id)
        {
            return await _dBContext.Models.Where(x => x.MakeId == id).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<Variant>> GetVarientListCountByIDAsync(int id)
        {
            return await _dBContext.Variants.Where(x => x.ModelId == id).ToListAsync();
        }
        public async System.Threading.Tasks.Task<List<getmodelList>> GetModelListAsync(int makeId)
        {
            return await _dBContext.Models.Where(x => x.MakeId == makeId).Select(x => new getmodelList
            {
                Id = x.Id,
                Name = x.Name,
                Popular = x.Popular
            }).ToListAsync();
        }
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetModelListForSideSearchAsync(int makeId)
        {
            var modelList = await _dBContext.Models.Where(x => x.MakeId == makeId).ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in modelList)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByModelIDAsync(x.Id)

                });
            }

            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetVariantListAsync(int modelId)
        {
            var varientList = await _dBContext.Variants.Where(x => x.ModelId == modelId).ToListAsync();
            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in varientList)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Varient,
                    ChildCount = await GetVehicleCountByVariantIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }

        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetVehicleTypeListAsync()
        {
            return await _dBContext.VehicleTypes.Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetYearListAsync()
        {
            return await _dBContext.Years.Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetTransmissionListAsync()
        {
            return await _dBContext.Transmissions.Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }


        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetSearchVehicleListAsync(SearchViewModel searchViewModel)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (!searchViewModel.MakeId.Equals("0"))
            {
                List<int> modelIds = await _dBContext.Models.Where(x => x.MakeId == Convert.ToInt64(searchViewModel.MakeId)).Select(x => x.Id).ToListAsync();
                vehicleList = await _dBContext.Vehicles.Where(x => modelIds.Contains(x.ModelId ?? 0)).ToListAsync();
            }
            if (!searchViewModel.YearId.Equals("0"))
            {
                List<int> yearIds = await _dBContext.Models.Where(x => x.YearId == Convert.ToInt64(searchViewModel.YearId)).Select(x => x.Id).ToListAsync();
                vehicleList = await _dBContext.Vehicles.Where(x => yearIds.Contains(x.ModelId ?? 0)).ToListAsync();
            }

            if (!searchViewModel.CarTypeId.Equals("0"))
            {
                vehicleList = await _dBContext.Vehicles.Where(x => x.VehicalTypeId == Convert.ToInt64(searchViewModel.CarTypeId)).ToListAsync();
            }
            if (!searchViewModel.CarModelId.Equals("0"))
            {
                vehicleList = await _dBContext.Vehicles.Where(x => x.ModelId == Convert.ToInt64(searchViewModel.CarModelId)).ToListAsync();
            }
            if (!searchViewModel.LocationId.Equals("0"))
            {
                vehicleList = await _dBContext.Vehicles.Where(x => x.LocationId == Convert.ToInt64(searchViewModel.LocationId)).ToListAsync();
            }

            List<VehicleViewModel> vehicleViewModels = new List<VehicleViewModel>();
            foreach (var x in vehicleList)
            {
                vehicleViewModels.Add(new VehicleViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Vin = x.Vin,
                    Odometers = x.Odometers,
                    Image = await _imageServiceRepository.GetImagesByModelAsync(x.ModelId ?? 0),
                    Year = await GetYearAsync(x.ModelId ?? 0),
                    Body = await GetBodyAsync(x.BodyTypeId),
                    FuelType = await GetFuelTypeAsync(x.FuelTypeId ?? 0),
                    Transmission = await GetTransmissionAsync(x.TransmissionId ?? 0),
                    Cylinders = await GetCylindersAsync(x.CylindersId ?? 0),
                    Type = await GetTypeAsync(x.VehicalTypeId ?? 0),
                    price = (decimal)x.Price,
                    IsFavourite = await _whistlistrepo.IsWhistlistAddedAsync(searchViewModel.UserId, x.Id),

                });
            }
            return vehicleViewModels;
        }

        public async System.Threading.Tasks.Task<string> GetYearAsync(int modelId)
        {
            var yearId = await _dBContext.Models.Where(x => x.Id == modelId).Select(x => x.YearId).FirstOrDefaultAsync();
            return await _dBContext.Years.Where(x => x.Id == yearId).Select(x => x.Name).FirstOrDefaultAsync();
        }
        public async System.Threading.Tasks.Task<string> GetBodyAsync(int bodyId)
        {
            return await _dBContext.BodyTypes.Where(x => x.Id == bodyId).Select(x => x.Name).FirstOrDefaultAsync();
        }
        public async System.Threading.Tasks.Task<string> GetFuelTypeAsync(int fuelId)
        {
            return await _dBContext.FuelTypes.Where(x => x.Id == fuelId).Select(x => x.Name).FirstOrDefaultAsync();
        }
        public async System.Threading.Tasks.Task<string> GetTransmissionAsync(int transmissionId)
        {
            return await _dBContext.Transmissions.Where(x => x.Id == transmissionId).Select(x => x.Name).FirstOrDefaultAsync();
        }
        public async System.Threading.Tasks.Task<string> GetCylindersAsync(int cylindersId)
        {
            return await _dBContext.Cylinders.Where(x => x.Id == cylindersId).Select(x => x.Name).FirstOrDefaultAsync();
        }
        public async System.Threading.Tasks.Task<string> GetTypeAsync(int typeId)
        {
            return await _dBContext.VehicleTypes.Where(x => x.Id == typeId).Select(x => x.Name).FirstOrDefaultAsync();
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedMakesAsync(List<int> makeId)
        {
            var modelIds = makeId.Count == 0 ? new List<int>(){0}: await _dBContext.Models.Where(x => makeId.Contains(x.MakeId)).Select(x => x.Id).ToListAsync();
            var vehicleData = await _dBContext.Vehicles.Where(x => modelIds.Contains(x.ModelId ?? 0)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByMakeIDAsync(int makeId)
        {
            List<int> lstmakeId = new List<int>
            {
                makeId
            };
            var lstVehicle = await GetVehicleListAccordingToSelectedMakesAsync(lstmakeId);
            return lstVehicle.Count();
        }

        public async System.Threading.Tasks.Task<int> GetVehicleCountByModelIDAsync(int modelId)
        {
            List<int> lstmodelId = new List<int>
            {
                modelId
            };
            var lstVehicle = await GetVehicleListAccordingToSelectedModelsAsync(lstmodelId);
            return lstVehicle.Count();
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByVariantIDAsync(int variantId)
        {
            List<int> lstvariantId = new List<int>
            {
                variantId
            };
            var lstVehicle = await GetVehicleListAccordingToSelectedVariantsAsync(lstvariantId);
            return lstVehicle.Count();
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedModelsAsync(List<int> lstmodelId)
        {
            var modelIds = lstmodelId.Count == 0 ? new List<int>() { 0 } : await _dBContext.Models.Where(x => lstmodelId.Contains(x.MakeId)).Select(x => x.Id).ToListAsync();
            var vehicleData = await _dBContext.Vehicles.Where(x => modelIds.Contains(x.ModelId ?? 0)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedVariantsAsync(List<int> lstvariantId)
        {
            var variantIds = lstvariantId.Count == 0 ? new List<int>() { 0 } : await _dBContext.Variants.Where(x => lstvariantId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            //return await _dBContext.Vehicles.Where(x => variantIds.Contains(x.Variant ?? 0)).ToListAsync();

            var vehicleData = await _dBContext.Vehicles.Where(x => variantIds.Contains(x.Variant ?? 0)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedPriceRangeAsync(List<Decimal> lstPrice)
        {
            var vehicleData = await _dBContext.Vehicles.Where(l => l.Price >= lstPrice[0] && l.Price <= lstPrice[1]).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedOdometerRangeAsync(List<int> lstOdometer)
        {
            var vehicleData = await _dBContext.Vehicles.Where(o => Convert.ToInt32(o.Odometers) >= lstOdometer[0] && Convert.ToInt32(o.Odometers) <= lstOdometer[1]).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedTransmissionAsync(List<int> lstTransmissionId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(t => lstTransmissionId.Contains(t.TransmissionId ?? 00)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }
        
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedYearAsync(List<int> lstYear)
        {
            var vehicleData = await _dBContext.Vehicles.Where(Y => Y.YearId >= lstYear[0] && Y.YearId <= lstYear[1]).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetFuelTypesListAsync()
        {
            var fuelTypes= await _dBContext.FuelTypes.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in fuelTypes)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByFuelTypesIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByFuelTypesIDAsync(int fuelTypesId)
        {
            List<int> lstFuelTypesId = new List<int>
            {
                fuelTypesId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByVehicleTypesAsync(lstFuelTypesId);
            return lstVehicle.Count();
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByVehicleTypesAsync(List<int> lstFuelTypesId)
        {
            var _lstFuelTypesIds = lstFuelTypesId.Count == 0 ? new List<int>() { 0 } : await _dBContext.FuelTypes.Where(x => lstFuelTypesId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstFuelTypesIds.Contains(x.FuelTypeId ?? 0)).ToListAsync(); 
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
                    ChildCount = await GetVehicleCountByCylindersIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByCylindersIDAsync(int CylindersId)
        {
            List<int> lstCylindersId = new List<int>
            {
                CylindersId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByCylindersAsync(lstCylindersId);
            return lstVehicle.Count();
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByCylindersAsync(List<int> lstCylindersId)
        {
            var _lstCylindersIds = lstCylindersId.Count == 0 ? new List<int>() { 0 } : await _dBContext.Cylinders.Where(x => lstCylindersId.Contains(x.Id)).Select(x => x.Id).ToListAsync();

            return await _dBContext.Vehicles.Where(x => _lstCylindersIds.Contains(x.CylindersId ?? 0)).ToListAsync(); 
        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetEngineSizeListAsync()
        {
            var engineSizes = await _dBContext.EngineSizes.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in engineSizes)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByEngineSizeIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByEngineSizeIDAsync(int EngineSizeId)
        {
            List<int> lstEngineSizeId = new List<int>
            {
                EngineSizeId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByEngineSizeAsync(lstEngineSizeId);

            return lstVehicle.Count(); 
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByEngineSizeAsync(List<int> lstEngineSizeId)
        {
            var _lstEngineSizeIds = lstEngineSizeId.Count == 0 ? new List<int>() { 0 } : await _dBContext.EngineSizes.Where(x => lstEngineSizeId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstEngineSizeIds.Contains(x.EngineSizeId ?? 0)).ToListAsync();
        }
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetFuelEconomyListAsync()
        {
            var fuelEconomies = await _dBContext.FuelEconomies.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in fuelEconomies)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByFuelEconomyIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByFuelEconomyIDAsync(int FuelEconomyId)
        {
            List<int> lstFuelEconomyId = new List<int>
            {
                FuelEconomyId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByFuelEconomyAsync(lstFuelEconomyId);
            return lstVehicle.Count(); 
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByFuelEconomyAsync(List<int> lstFuelEconomyId)
        {
            var _lstFuelEconomyIds = lstFuelEconomyId.Count == 0 ? new List<int>() { 0 } : await _dBContext.FuelEconomies.Where(x => lstFuelEconomyId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstFuelEconomyIds.Contains(x.FuelEconomyId ?? 0)).ToListAsync();

        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetEngineDescriptionListAsync()
        {
            var engineDescriptions = await _dBContext.EngineDescriptions.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in engineDescriptions)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByEngineDescriptionsIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByEngineDescriptionsIDAsync(int EngineDescriptionId)
        {
            List<int> lstEngineDescriptionId = new List<int>
            {
                EngineDescriptionId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByEngineDescriptionAsync(lstEngineDescriptionId);
            return lstVehicle.Count();
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByEngineDescriptionAsync(List<int> lstEngineDescriptionId)
        {
            var _lstEngineDescriptionIds = lstEngineDescriptionId.Count == 0 ? new List<int>() { 0 } : await _dBContext.EngineDescriptions.Where(x => lstEngineDescriptionId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstEngineDescriptionIds.Contains(x.EngineDescriptionId ?? 0)).ToListAsync();
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
                    ChildCount = await GetVehicleCountByColoursIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByColoursIDAsync(int ColourId)
        {
            List<int> lstColourId = new List<int>
            {
                ColourId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByColourAsync(lstColourId);
            return lstVehicle.Count(); 
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByColourAsync(List<int> lstColourId)
        {
            var _lstColourIds = lstColourId.Count == 0 ? new List<int>() { 0 } : await _dBContext.Colours.Where(x => lstColourId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstColourIds.Contains(x.ColourId ?? 0)).ToListAsync();

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
                    ChildCount = await GetVehicleCountByBodyTypesIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByBodyTypesIDAsync(int BodyTypeId)
        {
            List<int> lstBodyTypeId = new List<int>
            {
                BodyTypeId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByCylindersAsync(lstBodyTypeId);
            return lstVehicle.Count(); 
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByBodyTypeAsync(List<int> lstBodyTypeId)
        {
            var _lstBodyTypeIds = lstBodyTypeId.Count == 0 ? new List<int>() { 0 } : await _dBContext.BodyTypes.Where(x => lstBodyTypeId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstBodyTypeIds.Contains(x.BodyTypeId)).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedVehicleTypeAsync(List<int> lstVehicleTypeId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(t => lstVehicleTypeId.Contains(t.VehicalTypeId ?? 00)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedFuelTypeAsync(List<int> lstFuelTypeId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(t => lstFuelTypeId.Contains(t.FuelTypeId ?? 00)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedCylinderAsync(List<int> lstCylinderId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(t => lstCylinderId.Contains(t.CylindersId ?? 00)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }

        private async Task<List<VehicleViewModel>> GetVehicleViewModel(List<Vehicle> vehicleData)
        {
            List<VehicleViewModel> vehicleViewModels = new List<VehicleViewModel>();
            foreach (var x in vehicleData)
            {
                vehicleViewModels.Add(new VehicleViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Vin = x.Vin,
                    Odometers = x.Odometers,
                    Image = await _imageServiceRepository.GetImagesByModelAsync(x.ModelId ?? 0),
                    Year = await GetYearAsync(x.ModelId ?? 0),
                    Body = await GetBodyAsync(x.BodyTypeId),
                    FuelType = await GetFuelTypeAsync(x.FuelTypeId ?? 0),
                    Transmission = await GetTransmissionAsync(x.TransmissionId ?? 0),
                    Cylinders = await GetCylindersAsync(x.CylindersId ?? 0),
                    Type = await GetTypeAsync(x.VehicalTypeId ?? 0),
                    price = (decimal)x.Price
                });
            }
            return vehicleViewModels;
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedEngineSizeAsync(List<int> lstEngineSizeId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(t => lstEngineSizeId.Contains(t.EngineSizeId ?? 00)).ToListAsync();
            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedEngineDescriptionAsync(int engineDescriptionId)
        {            
             var vehicleData = await  _dBContext.Vehicles.Where(ed => ed.EngineDescriptionId == engineDescriptionId).ToListAsync();            
            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedFuelEconomyAsync(int fuelEconomyId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(ed => ed.FuelEconomyId == fuelEconomyId).ToListAsync();            
            return await GetVehicleViewModel(vehicleData);
        }
    }
}