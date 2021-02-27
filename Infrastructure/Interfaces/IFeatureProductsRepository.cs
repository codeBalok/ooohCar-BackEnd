using CarsbyEF.DataContracts;
using System.Collections.Generic;
using CarsbyServices.ViewModels;
namespace Core.Interfaces
{
    public interface IFeatureProductsRepository
    {
        System.Threading.Tasks.Task<List<VehicleViewModel>> GetProductsListAsync();
    }
}