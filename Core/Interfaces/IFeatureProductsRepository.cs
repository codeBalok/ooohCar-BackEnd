using CarsbyEF.DataContracts;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IFeatureProductsRepository
    {
        List<Vehicle> GetProductsList();
    }
}