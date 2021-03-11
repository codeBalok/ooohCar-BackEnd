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

        //public async System.Threading.Tasks.Task<List<CommonViewModel>> GetVehicleTypeListAsync()
        //{
        //    return await _dBContext.VehicleTypes.Select(x => new CommonViewModel
        //    {
        //        Id = x.Id,
        //        Name = x.Name
        //    }).ToListAsync();
        //}

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
            var modelIds = makeId.Count == 0 ? new List<int>() { 0 } : await _dBContext.Models.Where(x => makeId.Contains(x.MakeId)).Select(x => x.Id).ToListAsync();
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
            var fuelTypes = await _dBContext.FuelTypes.ToListAsync();

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
            List<Vehicle> lstVehicle = await GetVehicleListByBodyTypeAsync(lstBodyTypeId);
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
            var vehicleData = await _dBContext.Vehicles.Where(ed => ed.EngineDescriptionId == engineDescriptionId).ToListAsync();
            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedFuelEconomyAsync(int fuelEconomyId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(ed => ed.FuelEconomyId == fuelEconomyId).ToListAsync();
            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetInductionTurboListAsync()
        {
            var inductionTurboList = await _dBContext.InductionTurbos.ToListAsync();
            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in inductionTurboList)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByInductionTurboIdAsync(x.Id)
                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByInductionTurboIdAsync(int inductionTurboId)
        {
            List<int> lstInductionTurboId = new List<int>
            {
                inductionTurboId
            };
            var lstVehicle = await GetVehicleListAccordingToSelectedInductionTurboAsync(lstInductionTurboId);
            return lstVehicle.Count();
        }
        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListAccordingToSelectedInductionTurboAsync(List<int> lstInductionTurboId)
        {
            var _lstInductionTurboId = lstInductionTurboId.Count == 0 ? new List<int>() { 0 } : await _dBContext.InductionTurbos.Where(x => lstInductionTurboId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstInductionTurboId.Contains(x.InductionTurboId ?? 0)).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetTowListAsync()
        {
            var towList = await _dBContext.Tows.ToListAsync();
            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in towList)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByTowIdAsync(x.Id)
                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByTowIdAsync(int towId)
        {
            List<int> lstTowId = new List<int>
            {
                towId
            };
            var lstVehicle = await GetVehicleListAccordingToSelectedtowAsync(lstTowId);
            return lstVehicle.Count();
        }
        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListAccordingToSelectedtowAsync(List<int> lstTowId)
        {
            var _lstTowId = lstTowId.Count == 0 ? new List<int>() { 0 } : await _dBContext.InductionTurbos.Where(x => lstTowId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstTowId.Contains(x.TowId ?? 0)).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetPowerListAsync()
        {
            var PowerList = await _dBContext.Powers.ToListAsync();
            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in PowerList)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByPowerIdAsync(x.Id)
                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByPowerIdAsync(int PowerId)
        {
            List<int> lstPowerId = new List<int>
            {
                PowerId
            };
            var lstVehicle = await GetVehicleListAccordingToSelectedPowerAsync(lstPowerId);
            return lstVehicle.Count();
        }
        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListAccordingToSelectedPowerAsync(List<int> lstPowerId)
        {
            var _lstPowerId = lstPowerId.Count == 0 ? new List<int>() { 0 } : await _dBContext.Powers.Where(x => lstPowerId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstPowerId.Contains(x.PowerId ?? 0)).ToListAsync();
        }
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetPowerToWeightListAsync()
        {
            var PowerToWeightList = await _dBContext.PowerToWeights.ToListAsync();
            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in PowerToWeightList)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByPowerToWeightIdAsync(x.Id)
                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByPowerToWeightIdAsync(int PowerToWeightId)
        {
            List<int> lstPowerToWeightId = new List<int>
            {
                PowerToWeightId
            };
            var lstVehicle = await GetVehicleListAccordingToSelectedPowerToWeightAsync(lstPowerToWeightId);
            return lstVehicle.Count();
        }
        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListAccordingToSelectedPowerToWeightAsync(List<int> lstPowerToWeightId)
        {
            var _lstPowerToWeightId = lstPowerToWeightId.Count == 0 ? new List<int>() { 0 } : await _dBContext.PowerToWeights.Where(x => lstPowerToWeightId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstPowerToWeightId.Contains(x.PowerToWeightId ?? 0)).ToListAsync();
        }
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetDriveTypeListAsync()
        {
            var DriveTypeList = await _dBContext.DriveTypes.ToListAsync();
            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in DriveTypeList)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByDriveTypeIdAsync(x.Id)
                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByDriveTypeIdAsync(int DriveTypeId)
        {
            List<int> lstDriveTypeId = new List<int>
            {
                DriveTypeId
            };
            var lstVehicle = await GetVehicleListAccordingToSelectedDriveTypeAsync(lstDriveTypeId);
            return lstVehicle.Count();
        }
        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListAccordingToSelectedDriveTypeAsync(List<int> lstDriveTypeId)
        {
            var _lstDriveTypeId = lstDriveTypeId.Count == 0 ? new List<int>() { 0 } : await _dBContext.DriveTypes.Where(x => lstDriveTypeId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstDriveTypeId.Contains(x.DriveTypeId ?? 0)).ToListAsync();
        }


        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedInductionTurboAsync(int InductionTurboId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(ed => ed.InductionTurboId == InductionTurboId).ToListAsync();
            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedPowersAsync(List<int> lstPower)
        {
            var vehicleData = await _dBContext.Vehicles.Where(Y => Y.PowerId >= lstPower[0] && Y.PowerId <= lstPower[1]).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedPowerToWeightsAsync(List<int> lstPowerToWeight)
        {
            var vehicleData = await _dBContext.Vehicles.Where(Y => Y.PowerToWeightId >= lstPowerToWeight[0] && Y.PowerToWeightId <= lstPowerToWeight[1]).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedTowsAsync(List<int> lstTow)
        {
            var vehicleData = await _dBContext.Vehicles.Where(Y => Y.TowId >= lstTow[0] && Y.TowId <= lstTow[1]).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedDriveTypeAsync(int driveTypeId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(ed => ed.DriveTypeId == driveTypeId).ToListAsync();
            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedBodyTypeAsync(List<int> lstBodyTypeId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(t => lstBodyTypeId.Contains(t.BodyTypeId)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedColourAsync(List<int> lstColourId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(t => lstColourId.Contains(t.ColourId ?? 00)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetPriceListAsync()
        {
            return await _dBContext.Prices.Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = Convert.ToString(x.Amount ?? 00)
            }).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetSeatsListAsync()
        {
            return await _dBContext.Seats.Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = Convert.ToString(x.Name)
            }).ToListAsync();
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountBySeatsIDAsync(int SeatsId)
        {
            List<int> lstSeatsId = new List<int>
            {
                SeatsId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByVehicleSeatsAsync(lstSeatsId);
            return lstVehicle.Count();
        }
        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByVehicleSeatsAsync(List<int> lstSeatsId)
        {
            var _lstSeatsIds = lstSeatsId.Count == 0 ? new List<int>() { 0 } : await _dBContext.Seats.Where(x => lstSeatsId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstSeatsIds.Contains(x.SeatsId ?? 0)).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetLifeStylesListAsync()
        {
            var LifeStyles = await _dBContext.LifeStyles.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in LifeStyles)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByLifeStylesIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByLifeStylesIDAsync(int LifeStylesId)
        {
            List<int> lstLifeStylesId = new List<int>
            {
                LifeStylesId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByVehicleLifeStylesAsync(lstLifeStylesId);
            return lstVehicle.Count();
        }
        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByVehicleLifeStylesAsync(List<int> lstLifeStylesId)
        {
            var _lstLifeStylesIds = lstLifeStylesId.Count == 0 ? new List<int>() { 0 } : await _dBContext.LifeStyles.Where(x => lstLifeStylesId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstLifeStylesIds.Contains(x.LifeStylesId ?? 0)).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetDoorsListAsync()
        {
            var Doors = await _dBContext.Doors.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in Doors)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByDoorsIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByDoorsIDAsync(int DoorsId)
        {
            List<int> lstDoorsId = new List<int>
            {
                DoorsId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByVehicleDoorsAsync(lstDoorsId);
            return lstVehicle.Count();
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByVehicleDoorsAsync(List<int> lstDoorsId)
        {
            var _lstDoorsIds = lstDoorsId.Count == 0 ? new List<int>() { 0 } : await _dBContext.Doors.Where(x => lstDoorsId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstDoorsIds.Contains(x.DoorsId ?? 0)).ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedDoorsAsync(int doorsId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(ed => ed.DoorsId == doorsId).ToListAsync();
            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedLifeStylesAsync(int lifeStylesId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(ed => ed.LifeStylesId == lifeStylesId).ToListAsync();
            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedSeatsAsync(List<int> lstSeats)
        {
            var vehicleData = await _dBContext.Vehicles.Where(Y => Y.SeatsId >= lstSeats[0] && Y.SeatsId <= lstSeats[1]).ToListAsync();
            return await GetVehicleViewModel(vehicleData);
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedVehicelTypeAsync(List<int> lstVehicelTypeId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(t => lstVehicelTypeId.Contains(t.VehicalTypeId ?? 00)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }

        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetCertifiedInspectedListAsync()
        {
            var CertifiedInspected = await _dBContext.CertifiedInspecteds.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in CertifiedInspected)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByCertifiedInspectedIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByCertifiedInspectedIDAsync(int CertifiedInspectedId)
        {
            List<int> lstCertifiedInspectedId = new List<int>
            {
                CertifiedInspectedId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByCertifiedInspectedsAsync(lstCertifiedInspectedId);
            return lstVehicle.Count();
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByCertifiedInspectedsAsync(List<int> lstCertifiedInspectedId)
        {
            var _lstCertifiedInspectedIds = lstCertifiedInspectedId.Count == 0 ? new List<int>() { 0 } : await _dBContext.CertifiedInspecteds.Where(x => lstCertifiedInspectedId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstCertifiedInspectedIds.Contains(x.CertifiedInspectedId ?? 0)).ToListAsync();
        }
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedCertifiedInspectedAsync(List<int> lstCertifiedInspectedId)
        {
            var vehicleData = await _dBContext.Vehicles.Where(t => lstCertifiedInspectedId.Contains(t.CertifiedInspectedId ?? 00)).ToListAsync();

            return await GetVehicleViewModel(vehicleData);
        }


        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetVehicleTypeListAsync()
        {
            var VehicelTypes = await _dBContext.VehicleTypes.ToListAsync();

            List<SideSearchCommonViewModel> sideSearchCommonViewModels = new List<SideSearchCommonViewModel>();
            foreach (var x in VehicelTypes)
            {
                sideSearchCommonViewModels.Add(new SideSearchCommonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ChildCount = await GetVehicleCountByVehicleTypesIDAsync(x.Id)

                });
            }
            return sideSearchCommonViewModels;
        }
        public async System.Threading.Tasks.Task<int> GetVehicleCountByVehicleTypesIDAsync(int VehicelTypeId)
        {
            List<int> lstVehicelTypeId = new List<int>
            {
                VehicelTypeId
            };
            List<Vehicle> lstVehicle = await GetVehicleListByVehicleTypeAsync(lstVehicelTypeId);
            return lstVehicle.Count();
        }

        public async System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByVehicleTypeAsync(List<int> lstVehicelTypeId)
        {
            var _lstVehicleTypeIds = lstVehicelTypeId.Count == 0 ? new List<int>() { 0 } : await _dBContext.VehicleTypes.Where(x => lstVehicelTypeId.Contains(x.Id)).Select(x => x.Id).ToListAsync();
            return await _dBContext.Vehicles.Where(x => _lstVehicleTypeIds.Contains(x.VehicalTypeId ?? 0)).ToListAsync();

        }

    }

    
}