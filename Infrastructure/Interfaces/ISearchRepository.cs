using CarsbyEF.DataContracts;
using CarsbyServices.ViewModels;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ISearchRepository
    {
        System.Threading.Tasks.Task<List<getmakeList>> GetMakeListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetSideSearchMakeListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetModelListForSideSearchAsync(int makeId);
        System.Threading.Tasks.Task<List<getmodelList>> GetModelListAsync(int makeId);
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetVariantListAsync(int modelId);
        System.Threading.Tasks.Task<List<CommonViewModel>> GetLocationListAsync();
        System.Threading.Tasks.Task<List<CommonViewModel>> GetYearListAsync();
        System.Threading.Tasks.Task<List<CommonViewModel>> GetVehicleTypeListAsync();
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetSearchVehicleListAsync(SearchViewModel searchViewModel);
        System.Threading.Tasks.Task<string> GetYearAsync(int modelId);
        System.Threading.Tasks.Task<string> GetBodyAsync(int bodyId);
        System.Threading.Tasks.Task<string> GetFuelTypeAsync(int fuelId);
        System.Threading.Tasks.Task<string> GetTransmissionAsync(int transmissionId);
        System.Threading.Tasks.Task<string> GetCylindersAsync(int cylindersId);
        System.Threading.Tasks.Task<string> GetTypeAsync(int typeId);
        System.Threading.Tasks.Task<List<Model>> GetModalListCountByIDAsync(int id);
        System.Threading.Tasks.Task<List<Variant>> GetVarientListCountByIDAsync(int id);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedMakesAsync(List<int> makeIds);
        System.Threading.Tasks.Task<int> GetVehicleCountByMakeIDAsync(int makeId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedModelsAsync(List<int> lstmodelId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedVariantsAsync(List<int> lstvariantId);
        System.Threading.Tasks.Task<int> GetVehicleCountByModelIDAsync(int modelId);
        System.Threading.Tasks.Task<int> GetVehicleCountByVariantIDAsync(int variantId);
        System.Threading.Tasks.Task<List<CommonViewModel>> GetTransmissionListAsync();
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedPriceRangeAsync(List<decimal> prices);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedOdometerRangeAsync(List<int> lstOdometer);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedTransmissionAsync(List<int> lstTransmissionId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedYearAsync(List<int> lstYear);

        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetFuelTypesListAsync();
        System.Threading.Tasks.Task<int> GetVehicleCountByFuelTypesIDAsync(int fuelTypesId);
        System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByVehicleTypesAsync(List<int> lstFuelTypesId);
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetCylindersListAsync();
        System.Threading.Tasks.Task<int> GetVehicleCountByCylindersIDAsync(int CylindersId);
        System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByCylindersAsync(List<int> lstCylindersId);
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetEngineSizeListAsync();
        System.Threading.Tasks.Task<int> GetVehicleCountByEngineSizeIDAsync(int EngineSizeId);
        System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByEngineSizeAsync(List<int> lstEngineSizeId);
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetFuelEconomyListAsync();
        System.Threading.Tasks.Task<int> GetVehicleCountByFuelEconomyIDAsync(int FuelEconomyId);
        System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByFuelEconomyAsync(List<int> lstFuelEconomyId);
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetEngineDescriptionListAsync();
        System.Threading.Tasks.Task<int> GetVehicleCountByEngineDescriptionsIDAsync(int EngineDescriptionId);
        System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByEngineDescriptionAsync(List<int> lstEngineDescriptionId);
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetColourListAsync();
        System.Threading.Tasks.Task<int> GetVehicleCountByColoursIDAsync(int ColourId);
        System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByColourAsync(List<int> lstColourId);
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetBodyTypeListAsync();
        System.Threading.Tasks.Task<int> GetVehicleCountByBodyTypesIDAsync(int BodyTypeId);
        System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListByBodyTypeAsync(List<int> lstBodyTypeId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedVehicleTypeAsync(List<int> lstVehicleTypeId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedFuelTypeAsync(List<int> lstFuelTypeId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedCylinderAsync(List<int> lstCylinderId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedEngineSizeAsync(List<int> lstEngineSizeId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedEngineDescriptionAsync(int engineDescriptionId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedFuelEconomyAsync(int fuelEconomyId);
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetInductionTurboListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetPowerListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetPowerToWeightListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetTowListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetDriveTypeListAsync();
        System.Threading.Tasks.Task<int> GetVehicleCountByDriveTypeIdAsync(int DriveTypeId);
        System.Threading.Tasks.Task<List<Vehicle>> GetVehicleListAccordingToSelectedDriveTypeAsync(List<int> lstDriveTypeId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedInductionTurboAsync(int InductionTurboId);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedPowersAsync(List<int> lstPower);
        System.Threading.Tasks.Task<List<VehicleViewModel>>  GetVehicleListAccordingToSelectedPowerToWeightsAsync(List<int> lstPowerToWeight);
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedTowsAsync(List<int> lstTow);
    }
}