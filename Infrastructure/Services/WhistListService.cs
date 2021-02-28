using Core.Interfaces;
using CarsbyEF.DataContracts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarsbyServices.Services
{
    public class WhistListService : IWhistListRepository
    {
        private readonly CarBuyContext _dBContext;
        public WhistListService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async System.Threading.Tasks.Task<bool> IsWhistlistAddedAsync(string UserId, int vehicleId)
        {
            var whistlistalreadyadded = await _dBContext.WhistLists.Where(a => a.UserId == UserId && a.VehicleId == vehicleId).FirstOrDefaultAsync();
            if (whistlistalreadyadded != null)
            {
                if (whistlistalreadyadded.IsFavourite != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async System.Threading.Tasks.Task<string> addWhistlistAsync(WhistList WhistList)
        {
            if (WhistList != null)
            {
                var whistlistalreadyadded = await _dBContext.WhistLists.Where(a => a.UserId == WhistList.UserId && a.VehicleId == WhistList.VehicleId).FirstOrDefaultAsync();
                if (WhistList.Id == 0 && whistlistalreadyadded == null)
                {
                    _dBContext.WhistLists.Add(WhistList);
                    await _dBContext.SaveChangesAsync();
                    return "added";
                }
                else
                {
                    whistlistalreadyadded.IsFavourite = WhistList.IsFavourite;
                    _dBContext.WhistLists.Update(whistlistalreadyadded);
                    await _dBContext.SaveChangesAsync();
                    return "updated";
                }
            }
            else
            {
                return null;
            }
        }
    }
}

