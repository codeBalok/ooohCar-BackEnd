using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly ISearchRepository _searchRepository;
        private readonly IImageServiceRepository _imageServiceRepository;
        public HomeController(IImageServiceRepository imageServiceRepository, ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
            _imageServiceRepository = imageServiceRepository;
        }

        [HttpGet]
        [Route("GetVehicleList")]
        public List<CommonViewModel> GetVehicleList()
        {
            return _searchRepository.GetVehicleList().Select(x=> new CommonViewModel{
                Id= x.Id,
                Name = x.Name
            }).ToList();
        }
    
        [HttpGet]
        [Route("GetLocationList")]
        public List<CommonViewModel> GetLocationList()
        {
            return _searchRepository.GetLocationList().Select(x=> new CommonViewModel{
                Id= x.Id,
                Name = x.Name
            }).ToList();
        }

       

        [HttpGet]
        [Route("GetMakeList")]
        public List<CommonViewModel> GetMakeList()
        {
            return _searchRepository.GetMakeList().Select(x=> new CommonViewModel{
                Id= x.Id,
                Name = x.Name
            }).ToList();
        }
        [HttpGet]
        [Route("SideSearchGetMakeList")]
        public List<SideSearchCommonViewModel> SideSearchGetMakeList()
        {
            return _searchRepository.GetMakeList().Select(x => new SideSearchCommonViewModel
            {
                Id = x.Id,
                Name = x.Name
               // ChildCount= GetModelCountById(x.Id)
            }).ToList();
        }
        //public int GetModelCountById(int id)
        //{
        //    return _searchRepository.GetModalListCountByID(id).Count;
        //}


        [HttpGet]
        [Route("GetModelList/{makeId}")]
        public List<CommonViewModel> GetModelList(int makeId)
        {
            return _searchRepository.GetModelList().Where(x=>x.MakeId == makeId).Select(x=> new CommonViewModel{
                Id= x.Id,
                Name = x.Name
            }).ToList();
        }

        [HttpGet]
        [Route("GetModelListForSideSearch/{makeId}")]
        public List<SideSearchCommonViewModel> GetModelListForSideSearch(int makeId)
        {
            return _searchRepository.GetModelList().Where(x => x.MakeId == makeId).Select(x => new SideSearchCommonViewModel
            {
                Id = x.Id,
                Name = x.Name,
                //ChildCount=GetVarientCountById(x.Id)
            }).ToList();
        }

        [HttpGet]
        [Route("GetVariantListForSideSearch/{modelId}")]
        public List<SideSearchCommonViewModel> GetVariantListForSideSearch(int modelId)
        {
            return _searchRepository.GetVariantList().Where(x => x.ModelId == modelId).Select(x => new SideSearchCommonViewModel
            {
                Id = x.Id,
                Name = x.Varient
               
            }).ToList();
        }

        //public int GetVarientCountById(int id)
        //{
        //    return _searchRepository.GetVarientListCountByID(id).Count;
        //}

        [HttpGet]
        [Route("GetYearList")]
        public List<CommonViewModel> GetYearList()
        {
            return _searchRepository.GetYearList().Select(x=> new CommonViewModel{
                Id= x.Id,
                Name = x.Name
            }).ToList();
        }
    
        [HttpPost]
        [Route("GetSearchVehicleList")]
        public List<VehicleViewModel> GetSearchVehicleList([FromBody] SearchViewModel searchViewModel)
        {
           return _searchRepository.GetSearchVehicleList(searchViewModel.CarTypeId, searchViewModel.MakeId, searchViewModel.CarModelId, searchViewModel.LocationId, searchViewModel.YearId).
           Select(x=> new VehicleViewModel {
               Id = x.Id,
               Name = x.Name,
               Vin = x.Vin,
               Odometers = x.Odometers,
               Image = _imageServiceRepository.GetImagesByModel(x.ModelId ?? 0),
               Year = _searchRepository.GetYear(x.ModelId ?? 0),
               Body = _searchRepository.GetBody(x.BodyTypeId),
               FuelType = _searchRepository.GetFuelType(x.FuelTypeId ?? 0),
               Transmission = _searchRepository.GetTransmission(x.TransmissionId ?? 0),
               Cylinders = _searchRepository.GetCylinders(x.CylindersId ?? 0),
               Type = _searchRepository.GetType(x.VehicalTypeId ?? 0),
           }).ToList();
        }
    }
}