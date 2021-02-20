using System.Threading.Tasks;
using Core.Models;
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
         int GetVehcileCountByMakeID(int makeId);
        List<Vehicle> GetVehicleListAccordingToSelectedModels(List<int> lstmodelId);
        List<Vehicle> GetVehicleListAccordingToSelectedVariants(List<int> lstvariantId);        
        int GetVehcileCountByModelID(int modelId);
        int GetVehcileCountByVariantID(int variantId);
        List<Transmission> GetTransmissionList();
        List<Vehicle> GetVehicleListAccordingToSelectedPriceRange(List<decimal> prices);
        List<Vehicle> GetVehicleListAccordingToSelectedOdometerRange(List<int> lstOdometer);
        List<Vehicle> GetVehicleListAccordingToSelectedTransmission(List<int> lstTransmissionId);
        List<Vehicle>  GetVehicleListAccordingToSelectedYear(List<int> lstYear);
        //List<CertifiedInspected> GetCertifiedInspectedList();
    }
}