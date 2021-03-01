using API.Controllers;
using CarsbyServices.Interfaces;
using CarsbyServices.ViewModels;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsbyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddVehicleController : BaseApiController
    {
        private readonly IAddVehicleRepository _addvehiclerepo;
        public AddVehicleController(IAddVehicleRepository addvehiclerepo)
        {
            _addvehiclerepo = addvehiclerepo;
        }

        [HttpGet]
        [Route("GetMakeListAddVehicle")]
        public async System.Threading.Tasks.Task<List<getmakeList>> GetMakeListForAddVehicleAsync()
        {
            return await _addvehiclerepo.GetMakeListForAddVehicleAsync();
        }
        [HttpGet]
        [Route("GetModelList/{makeId}")]
        public async System.Threading.Tasks.Task<List<getmodelList>> GetModelListAsync(int makeId)
        {
            return await _addvehiclerepo.GetModelListAsync(makeId);
        }
    }
}
