using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IWhistListRepository
    {
        string addWhistlist(WhistList WhistList);
        bool IsWhistlistAdded(string UserId, int vehicleId);
    }
}
