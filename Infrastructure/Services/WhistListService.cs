using Core.Interfaces;
using CarsbyEF.DataContracts;
using System.Linq;

namespace Infrastructure.Services
{
    public class WhistListService : IWhistListRepository
    {
        private readonly CarBuyContext _dBContext;
        public WhistListService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }

        public bool IsWhistlistAdded(string UserId, int vehicleId)
        {
            var whistlistalreadyadded = _dBContext.WhistLists.Where(a => a.UserId == UserId && a.VehicleId == vehicleId).FirstOrDefault();
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

        public string addWhistlist(WhistList WhistList)
        {
            if (WhistList != null)
            {
                var whistlistalreadyadded = _dBContext.WhistLists.Where(a => a.UserId == WhistList.UserId && a.VehicleId == WhistList.VehicleId).FirstOrDefault();
                if (WhistList.Id == 0 && whistlistalreadyadded == null)
                {
                    _dBContext.WhistLists.Add(WhistList);
                    _dBContext.SaveChanges();
                    return "added";
                }
                else
                {
                    whistlistalreadyadded.IsFavourite = WhistList.IsFavourite;
                    _dBContext.WhistLists.Update(whistlistalreadyadded);
                    _dBContext.SaveChanges();
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

