using CarsbyEF.DataContracts;

namespace Core.Interfaces
{
    public interface IWhistListRepository
    {
        string addWhistlist(WhistList WhistList);
        bool IsWhistlistAdded(string UserId, int vehicleId);
    }
}
