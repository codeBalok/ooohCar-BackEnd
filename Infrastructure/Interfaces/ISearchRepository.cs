using CarsbyEF.DataContracts;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ISearchRepository
    {
        List<Make> GetMakeList();
        List<Model> GetModelList();
        List<Variant> GetVariantList();
        List<Location> GetLocationList();
        List<Year> GetYearList();
        List<VehicleType> GetVehicleTypeList();
        List<Vehicle> GetSearchVehicleList(string carTypeId, string makeId, string carModelId, string locationId, string yearId);
        string GetYear(int modelId);
        string GetBody(int bodyId);
        string GetFuelType(int fuelId);
        string GetTransmission(int transmissionId);
        string GetCylinders(int cylindersId);
        string GetType(int typeId);
        List<Model> GetModalListCountByID(int id);
        List<Variant> GetVarientListCountByID(int id);
        List<Vehicle> GetVehicleListAccordingToSelectedMakes(List<int> makeIds);
        int GetVehicleCountByMakeID(int makeId);
        List<Vehicle> GetVehicleListAccordingToSelectedModels(List<int> lstmodelId);
        List<Vehicle> GetVehicleListAccordingToSelectedVariants(List<int> lstvariantId);
        int GetVehicleCountByModelID(int modelId);
        int GetVehicleCountByVariantID(int variantId);
        List<Transmission> GetTransmissionList();
        List<Vehicle> GetVehicleListAccordingToSelectedPriceRange(List<decimal> prices);
        List<Vehicle> GetVehicleListAccordingToSelectedOdometerRange(List<int> lstOdometer);
        List<Vehicle> GetVehicleListAccordingToSelectedTransmission(List<int> lstTransmissionId);
        List<Vehicle> GetVehicleListAccordingToSelectedYear(List<int> lstYear);
        //List<CertifiedInspected> GetCertifiedInspectedList();
        List<FuelType> GetFuelTypesList();
        int GetVehicleCountByFuelTypesID(int fuelTypesId);
        List<Vehicle> GetVehicleListByVehicleTypes(List<int> lstFuelTypesId);
        List<Cylinder> GetCylindersList();
        int GetVehicleCountByCylindersID(int CylindersId);
        List<Vehicle> GetVehicleListByCylinders(List<int> lstCylindersId);
        List<EngineSize> GetEngineSizeList();
        int GetVehicleCountByEngineSizeID(int EngineSizeId);
        List<Vehicle> GetVehicleListByEngineSize(List<int> lstEngineSizeId);
        List<FuelEconomy> GetFuelEconomyList();
        int GetVehicleCountByFuelEconomyID(int FuelEconomyId);
        List<Vehicle> GetVehicleListByFuelEconomy(List<int> lstFuelEconomyId);
        List<EngineDescription> GetEngineDescriptionList();
        int GetVehicleCountByEngineDescriptionsID(int EngineDescriptionId);
        List<Vehicle> GetVehicleListByEngineDescription(List<int> lstEngineDescriptionId);
        List<Colour> GetColourList();
        int GetVehicleCountByColoursID(int ColourId);
        List<Vehicle> GetVehicleListByColour(List<int> lstColourId);
        List<BodyType> GetBodyTypeList();
        int GetVehicleCountByBodyTypesID(int BodyTypeId);
        List<Vehicle> GetVehicleListByBodyType(List<int> lstBodyTypeId);
    }
}