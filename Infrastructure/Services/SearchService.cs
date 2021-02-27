using Core.Interfaces;
using CarsbyEF.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class SearchService : ISearchRepository
    {
        private readonly CarBuyContext _dBContext;
        public SearchService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<Location> GetLocationList()
        {
            return _dBContext.Locations.ToList();
        }

        public List<Make> GetMakeList()
        {
            return _dBContext.Makes.ToList();
        }
        public List<Model> GetModalListCountByID(int id)
        {
            return _dBContext.Models.Where(x => x.MakeId == id).ToList();
        }

        public List<Variant> GetVarientListCountByID(int id)
        {
            return _dBContext.Variants.Where(x => x.ModelId == id).ToList();
        }
        public List<Model> GetModelList()
        {
            return _dBContext.Models.ToList();
        }
        public List<Variant> GetVariantList()
        {
            return _dBContext.Variants.ToList();
        }

        public List<VehicleType> GetVehicleTypeList()
        {
            return _dBContext.VehicleTypes.ToList();
        }

        public List<Year> GetYearList()
        {
            return _dBContext.Years.ToList();
        }
        public List<Transmission> GetTransmissionList()
        {
            return _dBContext.Transmissions.ToList();
        }


        public List<Vehicle> GetSearchVehicleList(string carTypeId, string makeId, string carModelId, string locationId, string yearId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            vehicleList = _dBContext.Vehicles.ToList();
            if (!makeId.Equals("0"))
            {
                List<int> modelIds = _dBContext.Models.Where(x => x.MakeId == Convert.ToInt64(makeId)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => modelIds.Contains(x.ModelId ?? 0)).ToList();
            }
            if (!yearId.Equals("0"))
            {
                List<int> yearIds = _dBContext.Models.Where(x => x.YearId == Convert.ToInt64(yearId)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => yearIds.Contains(x.ModelId ?? 0)).ToList();
            }

            if (!carTypeId.Equals("0"))
            {
                vehicleList = vehicleList.Where(x => x.VehicalTypeId == Convert.ToInt64(carTypeId)).ToList();
            }
            if (!carModelId.Equals("0"))
            {
                vehicleList = vehicleList.Where(x => x.ModelId == Convert.ToInt64(carModelId)).ToList();
            }
            if (!locationId.Equals("0"))
            {
                vehicleList = vehicleList.Where(x => x.LocationId == Convert.ToInt64(locationId)).ToList();
            }

            return vehicleList;
        }

        public string GetYear(int modelId)
        {
            var yearId = _dBContext.Models.Where(x => x.Id == modelId).Select(x => x.YearId).FirstOrDefault();
            return _dBContext.Years.Where(x => x.Id == yearId).Select(x => x.Name).FirstOrDefault();
        }
        public string GetBody(int bodyId)
        {
            return _dBContext.BodyTypes.Where(x => x.Id == bodyId).Select(x => x.Name).FirstOrDefault();
        }
        public string GetFuelType(int fuelId)
        {
            return _dBContext.FuelTypes.Where(x => x.Id == fuelId).Select(x => x.Name).FirstOrDefault();
        }
        public string GetTransmission(int transmissionId)
        {
            return _dBContext.Transmissions.Where(x => x.Id == transmissionId).Select(x => x.Name).FirstOrDefault();
        }
        public string GetCylinders(int cylindersId)
        {
            return _dBContext.Cylinders.Where(x => x.Id == cylindersId).Select(x => x.Name).FirstOrDefault();
        }
        public string GetType(int typeId)
        {
            return _dBContext.VehicleTypes.Where(x => x.Id == typeId).Select(x => x.Name).FirstOrDefault();
        }

        public List<Vehicle> GetVehicleListAccordingToSelectedMakes(List<int> makeId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (makeId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> modelIds = _dBContext.Models.Where(x => makeId.Contains(x.MakeId)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => modelIds.Contains(x.ModelId ?? 0)).ToList();
            }
            return vehicleList;
        }
        public int GetVehicleCountByMakeID(int makeId)
        {
            List<int> lstmakeId = new List<int>();
            lstmakeId.Add(makeId);
            List<Vehicle> lstVehicle = GetVehicleListAccordingToSelectedMakes(lstmakeId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }

        public int GetVehicleCountByModelID(int modelId)
        {
            List<int> lstmodelId = new List<int>();
            lstmodelId.Add(modelId);
            List<Vehicle> lstVehicle = GetVehicleListAccordingToSelectedModels(lstmodelId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }
        public int GetVehicleCountByVariantID(int variantId)
        {
            List<int> lstvariantId = new List<int>();
            lstvariantId.Add(variantId);
            List<Vehicle> lstVehicle = GetVehicleListAccordingToSelectedVariants(lstvariantId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }
        public List<Vehicle> GetVehicleListAccordingToSelectedModels(List<int> lstmodelId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstmodelId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> modelIds = _dBContext.Models.Where(x => lstmodelId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => modelIds.Contains(x.ModelId ?? 0)).ToList();
            }
            return vehicleList;
        }
        //public List<Vehicle> GetVehicleListAccordingToSelectedVariant(List<int> lstvariantId)
        //{
        //    List<Vehicle> vehicleList = new List<Vehicle>();
        //    if (lstvariantId.Count() > 0)
        //    {
        //        vehicleList = _dBContext.Vehicle.ToList();
        //        List<int> variantIds = _dBContext.Variant.Where(x => lstvariantId.Contains(x.Id)).Select(x => x.Id).ToList();
        //        vehicleList = vehicleList.Where(x => variantIds.Contains(x.Variant ?? 0)).ToList();
        //    }
        //    return vehicleList;
        //}
        public List<Vehicle> GetVehicleListAccordingToSelectedVariants(List<int> lstvariantId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstvariantId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> variantIds = _dBContext.Variants.Where(x => lstvariantId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => variantIds.Contains(x.Variant ?? 0)).ToList();
            }
            return vehicleList;
        }

        public List<Vehicle> GetVehicleListAccordingToSelectedPriceRange(List<Decimal> lstPrice)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstPrice.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                vehicleList = vehicleList.Where(l => l.Price >= lstPrice[0] && l.Price <= lstPrice[1]).ToList();
            }
            return vehicleList;

        }
        public List<Vehicle> GetVehicleListAccordingToSelectedOdometerRange(List<int> lstOdometer)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstOdometer.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                vehicleList = vehicleList.Where(o => Convert.ToInt32(o.Odometers) >= lstOdometer[0] && Convert.ToInt32(o.Odometers) <= lstOdometer[1]).ToList();
            }
            return vehicleList;
        }


        public List<Vehicle> GetVehicleListAccordingToSelectedTransmission(List<int> lstTransmissionId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstTransmissionId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                vehicleList = vehicleList.Where(t => lstTransmissionId.Contains(t.TransmissionId ?? 00)).ToList();
            }
            return vehicleList;
        }

        public List<Vehicle> GetVehicleListAccordingToSelectedYear(List<int> lstYear)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstYear.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                vehicleList = vehicleList.Where(Y => Y.YearId >= lstYear[0] && Y.YearId <= lstYear[1]).ToList();
            }
            return vehicleList;
        }

        /* public List<string> GetCertifiedInspectedList()
         {



             List<Vehicle> vehicleList = new List<Vehicle>();
             if (lstYear.Count() > 0)
             {
                 vehicleList = _dBContext.Vehicle.ToList();
                 vehicleList = vehicleList.Where(Y => Y.YearId >= lstYear[0] && Y.YearId <= lstYear[1]).ToList();
             }
             return vehicleList;
        }*/

        public List<FuelType> GetFuelTypesList()
        {
            return _dBContext.FuelTypes.ToList();
        }
        public int GetVehicleCountByFuelTypesID(int fuelTypesId)
        {
            List<int> lstFuelTypesId = new List<int>();
            lstFuelTypesId.Add(fuelTypesId);
            List<Vehicle> lstVehicle = GetVehicleListByVehicleTypes(lstFuelTypesId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }

        public List<Vehicle> GetVehicleListByVehicleTypes(List<int> lstFuelTypesId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstFuelTypesId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> _lstFuelTypesIds = _dBContext.FuelTypes.Where(x => lstFuelTypesId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => _lstFuelTypesIds.Contains(x.FuelTypeId ?? 0)).ToList();
            }
            return vehicleList;
        }

        public List<Cylinder> GetCylindersList()
        {
            return _dBContext.Cylinders.ToList();
        }
        public int GetVehicleCountByCylindersID(int CylindersId)
        {
            List<int> lstCylindersId = new List<int>();
            lstCylindersId.Add(CylindersId);
            List<Vehicle> lstVehicle = GetVehicleListByCylinders(lstCylindersId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }

        public List<Vehicle> GetVehicleListByCylinders(List<int> lstCylindersId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstCylindersId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> _lstCylindersIds = _dBContext.Cylinders.Where(x => lstCylindersId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => _lstCylindersIds.Contains(x.CylindersId ?? 0)).ToList();
            }
            return vehicleList;
        }

        public List<EngineSize> GetEngineSizeList()
        {
            return _dBContext.EngineSizes.ToList();
        }
        public int GetVehicleCountByEngineSizeID(int EngineSizeId)
        {
            List<int> lstEngineSizeId = new List<int>();
            lstEngineSizeId.Add(EngineSizeId);
            List<Vehicle> lstVehicle = GetVehicleListByEngineSize(lstEngineSizeId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }

        public List<Vehicle> GetVehicleListByEngineSize(List<int> lstEngineSizeId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstEngineSizeId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> _lstEngineSizeIds = _dBContext.EngineSizes.Where(x => lstEngineSizeId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => _lstEngineSizeIds.Contains(x.EngineSizeId ?? 0)).ToList();
            }
            return vehicleList;
        }
        public List<FuelEconomy> GetFuelEconomyList()
        {
            return _dBContext.FuelEconomies.ToList();
        }
        public int GetVehicleCountByFuelEconomyID(int FuelEconomyId)
        {
            List<int> lstFuelEconomyId = new List<int>();
            lstFuelEconomyId.Add(FuelEconomyId);
            List<Vehicle> lstVehicle = GetVehicleListByFuelEconomy(lstFuelEconomyId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }

        public List<Vehicle> GetVehicleListByFuelEconomy(List<int> lstFuelEconomyId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstFuelEconomyId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> _lstFuelEconomyIds = _dBContext.FuelEconomies.Where(x => lstFuelEconomyId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => _lstFuelEconomyIds.Contains(x.FuelEconomyId ?? 0)).ToList();
            }
            return vehicleList;
        }

        public List<EngineDescription> GetEngineDescriptionList()
        {
            return _dBContext.EngineDescriptions.ToList();
        }
        public int GetVehicleCountByEngineDescriptionsID(int EngineDescriptionId)
        {
            List<int> lstEngineDescriptionId = new List<int>();
            lstEngineDescriptionId.Add(EngineDescriptionId);
            List<Vehicle> lstVehicle = GetVehicleListByEngineDescription(lstEngineDescriptionId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }

        public List<Vehicle> GetVehicleListByEngineDescription(List<int> lstEngineDescriptionId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstEngineDescriptionId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> _lstEngineDescriptionIds = _dBContext.EngineDescriptions.Where(x => lstEngineDescriptionId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => _lstEngineDescriptionIds.Contains(x.EngineDescriptionId ?? 0)).ToList();
            }
            return vehicleList;
        }
        public List<Colour> GetColourList()
        {
            return _dBContext.Colours.ToList();
        }
        public int GetVehicleCountByColoursID(int ColourId)
        {
            List<int> lstColourId = new List<int>();
            lstColourId.Add(ColourId);
            List<Vehicle> lstVehicle = GetVehicleListByColour(lstColourId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }

        public List<Vehicle> GetVehicleListByColour(List<int> lstColourId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstColourId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> _lstColourIds = _dBContext.Colours.Where(x => lstColourId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => _lstColourIds.Contains(x.ColourId ?? 0)).ToList();
            }
            return vehicleList;
        }

        public List<BodyType> GetBodyTypeList()
        {
            return _dBContext.BodyTypes.ToList();
        }
        public int GetVehicleCountByBodyTypesID(int BodyTypeId)
        {
            List<int> lstBodyTypeId = new List<int>();
            lstBodyTypeId.Add(BodyTypeId);
            List<Vehicle> lstVehicle = GetVehicleListByCylinders(lstBodyTypeId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }

        public List<Vehicle> GetVehicleListByBodyType(List<int> lstBodyTypeId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstBodyTypeId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicles.ToList();
                List<int> _lstBodyTypeIds = _dBContext.BodyTypes.Where(x => lstBodyTypeId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => _lstBodyTypeIds.Contains(x.BodyTypeId)).ToList();
            }
            return vehicleList;
        }
    }
}