using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using CarsbyEF.DataContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhistListController : BaseApiController
    {
        private readonly IWhistListRepository _whistlistrepo;
        private readonly IMapper _mapper;
        public WhistListController(IWhistListRepository whistlistrepo)
        {
            _whistlistrepo = whistlistrepo;
        }

        [HttpPost]
        [Route("AddFavourite")]
        public async Task<IActionResult> addFavourite(WhistListDto whiatlistVM)
        {
            try
            {
                WhistList objWhistList = new WhistList();
                objWhistList.Id = whiatlistVM.Id;
                objWhistList.IsFavourite = whiatlistVM.IsFavourite;
                objWhistList.UserId = whiatlistVM.UserId;
                objWhistList.VehicleId = whiatlistVM.VehicleId;
                return Ok(_whistlistrepo.addWhistlist(objWhistList));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
