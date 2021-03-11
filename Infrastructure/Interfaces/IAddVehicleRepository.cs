using CarsbyServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using CarsbyEF.DataContracts;

namespace CarsbyServices.Interfaces
{
    public interface IAddVehicleRepository
    {

        System.Threading.Tasks.Task<List<getmodelList>> GetModelListAsync(int makeId);
        System.Threading.Tasks.Task<List<getvarientList>> GetVarientListAsync(int modelId);
        System.Threading.Tasks.Task<List<getmakeList>> GetMakeListForAddVehicleAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetFuelTypesListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetYearListAsync();
        System.Threading.Tasks.Task<List<ConditionViewModel>> GetConditionListAsync();
        System.Threading.Tasks.Task<List<PriceViewModel>> GetPriceListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetTrasmissionListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetBodyTypeListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetCylindersListAsync();
        System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetColourListAsync();
        System.Threading.Tasks.Task<string> AddUpdateNewVehicleAsync(Vehicle objvehicleToSave);
    }
}
