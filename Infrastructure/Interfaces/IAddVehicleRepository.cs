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
        System.Threading.Tasks.Task<List<getmakeList>> GetMakeListForAddVehicleAsync();
    }
}
