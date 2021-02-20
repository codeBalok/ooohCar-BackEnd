using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class WhistListService : IWhistListRepository
    {
        private readonly CarBuyContext _dBContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWhistListRepository _whistList;

        public WhistListService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }

        public bool IsWhistlistAdded(string UserId, int vehicleId)
        {
            var whistlistalreadyadded = _dBContext.WhistList.Where(a => a.UserId == UserId && a.VehicleId == vehicleId).FirstOrDefault();
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
               var whistlistalreadyadded = _dBContext.WhistList.Where(a => a.UserId == WhistList.UserId && a.VehicleId==WhistList.VehicleId).FirstOrDefault();
                if (WhistList.Id == 0 && whistlistalreadyadded==null)
                {
                    _dBContext.WhistList.Add(WhistList);
                    _dBContext.SaveChanges();
                    return "added";
                }
                else
                {
                    whistlistalreadyadded.IsFavourite = WhistList.IsFavourite;
                    _dBContext.WhistList.Update(whistlistalreadyadded);
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

