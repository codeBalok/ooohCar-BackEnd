using CarsbyEF.DataContracts;

namespace Core.Interfaces
{
    public interface IWhistListRepository
    {
        System.Threading.Tasks.Task<string> addWhistlistAsync(WhistList WhistList);
        System.Threading.Tasks.Task<bool> IsWhistlistAddedAsync(string UserId, int vehicleId);
    }
}
