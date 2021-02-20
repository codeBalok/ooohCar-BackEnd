using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Models;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using API.Extensions;
using System.Net.Http;

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
