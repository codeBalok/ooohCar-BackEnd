using System.Threading.Tasks;
using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IFeatureProductsRepository
    {
         List<Vehicle> GetProductsList();
    }
}