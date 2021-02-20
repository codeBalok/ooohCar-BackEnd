using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Common;
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
        private readonly IWhistListRepository _whistlistrepo;
        public HomeController(IImageServiceRepository imageServiceRepository, ISearchRepository searchRepository, IWhistListRepository whistlistrepo)
        {
            _searchRepository = searchRepository;
            _imageServiceRepository = imageServiceRepository;
            _whistlistrepo = whistlistrepo;
        }

        [HttpGet]
        [Route("GetVehicleTypeList")]
        public List<CommonViewModel> GetVehicleTypeList()
        {
            return _searchRepository.GetVehicleTypeList().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        [HttpGet]
        [Route("GetLocationList")]
        public List<CommonViewModel> GetLocationList()
        {
            return _searchRepository.GetLocationList().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }



        [HttpGet]
        [Route("GetMakeList")]
        public List<getmakeList> GetMakeList()
        {
            string currentpath = System.IO.Directory.GetCurrentDirectory();
            return _searchRepository.GetMakeList().Select(x => new getmakeList
            {
                Id = x.Id,
                Name = x.Name,
                LogoImages= Utility.ByteToBase64(currentpath+x.LogoImage)
        }).ToList();
        }
        [HttpGet]
        [Route("SideSearchGetMakeList")]
        public List<SideSearchCommonViewModel> SideSearchGetMakeList()
        {
            return _searchRepository.GetMakeList().Select(x => new SideSearchCommonViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ChildCount = GetVehcileCountByMakeID(x.Id)

            }).Where(x => x.ChildCount > 0).ToList();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public int GetVehcileCountByMakeID(int id)
        {
            return _searchRepository.GetVehcileCountByMakeID(id);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public int GetModelCountById(int id)
        {
            return _searchRepository.GetModalListCountByID(id).Count;
        }


        [HttpGet]
        [Route("GetModelList/{makeId}")]
        public List<getmodelList> GetModelList(int makeId)
        {
            var model= _searchRepository.GetModelList().Where(x => x.MakeId == makeId).Select(x => new getmodelList
            {
                Id = x.Id,
                Name = x.Name,
                Popular=x.Popular
            }).ToList();
            return model;
        }

        [HttpGet]
        [Route("GetModelListForSideSearch/{makeId}")]
        public List<SideSearchCommonViewModel> GetModelListForSideSearch(int makeId)
        {
            return _searchRepository.GetModelList().Where(x => x.MakeId == makeId).Select(x => new SideSearchCommonViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ChildCount = GetVehcileCountByModelID(x.Id)
            }).ToList();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public int GetVehcileCountByModelID(int id)
        {
            return _searchRepository.GetVehcileCountByModelID(id);
        }


        [HttpGet]
        [Route("GetVariantListForSideSearch/{modelId}")]
        public List<SideSearchCommonViewModel> GetVariantListForSideSearch(int modelId)
        {
            return _searchRepository.GetVariantList().Where(x => x.ModelId == modelId).Select(x => new SideSearchCommonViewModel
            {
                Id = x.Id,
                Name = x.Varient,
                ChildCount = GetVehcileCountByVariantID(x.Id)
            }).ToList();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public int GetVehcileCountByVariantID(int id)
        {
            return _searchRepository.GetVehcileCountByVariantID(id);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public int GetVarientCountById(int id)
        {
            return _searchRepository.GetVarientListCountByID(id).Count;
        }

        [HttpGet]
        [Route("GetYearList")]
        public List<CommonViewModel> GetYearList()
        {
            return _searchRepository.GetYearList().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        [HttpGet]
        [Route("GetTransmissionList")]
        public List<CommonViewModel> GetTransmissionList()
        {
            return _searchRepository.GetTransmissionList().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        [HttpGet]
        [Route("GetCertifiedInspectedList")]
        public List<CommonViewModel> GetCertifiedInspectedList()
        {
            List<CommonViewModel> cmlst = new List<CommonViewModel>();
            CommonViewModel CertfiedcommonViewModel = new CommonViewModel
            {
                Id = 1,
                Name = "Certified"
            };
            CommonViewModel InspectedcommonViewModel = new CommonViewModel
            {
                Id = 2,
                Name = "Inspected"
            };

            cmlst.Add(CertfiedcommonViewModel);
            cmlst.Add(InspectedcommonViewModel);

            return cmlst;

            /*return _searchRepository.GetCertifiedInspectedList().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();*/
        }

        

            [HttpPost]
        [Route("GetSearchVehicleList")]
        public List<VehicleViewModel> GetSearchVehicleList([FromBody] SearchViewModel searchViewModel)
        {

            return _searchRepository.GetSearchVehicleList(searchViewModel.CarTypeId, searchViewModel.MakeId, searchViewModel.CarModelId, searchViewModel.LocationId, searchViewModel.YearId).
            Select(x => new VehicleViewModel
            {
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
                price = x.Price,
                IsFavourite=_whistlistrepo.IsWhistlistAdded(searchViewModel.UserId, x.Id),
            }).ToList();
        }


        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedMakes")]
        public List<VehicleViewModel> GetVehicleListAccordingToSelectedMakes([FromBody] SelectedMakesListsViewModel selectedMakesListsViewModel)
        {

            List<int> makeIds = selectedMakesListsViewModel.Make.Select(makeId => makeId.Id).ToList();
            return _searchRepository.GetVehicleListAccordingToSelectedMakes(makeIds).
            Select(x => new VehicleViewModel
            {
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
                price = x.Price
            }).ToList();
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedModels")]
        public List<VehicleViewModel> GetVehicleListAccordingToSelectedModels([FromBody] SelectedModelsListsViewModel selectedModelsListsViewModel)
        {

            List<int> modelIds = selectedModelsListsViewModel.Model.Select(models => models.Id).ToList();
            return _searchRepository.GetVehicleListAccordingToSelectedModels(modelIds).
            Select(x => new VehicleViewModel
            {
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
                price = x.Price
            }).ToList();
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedVariants")]
        public List<VehicleViewModel> GetVehicleListAccordingToSelectedVariants([FromBody] SelectedVariantsListsViewModel selectedVariantsListsViewModel)
        {

            List<int> variantIds = selectedVariantsListsViewModel.Variant.Select(variant => variant.Id).ToList();
            return _searchRepository.GetVehicleListAccordingToSelectedVariants(variantIds).
            Select(x => new VehicleViewModel
            {
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
                price = x.Price
            }).ToList();
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedPriceRange")]
        public List<VehicleViewModel> GetVehicleListAccordingToSelectedPriceRange([FromBody] SearchVehicelListPriceModel searchVehicelListPriceModel)
        {
            
            return _searchRepository.GetVehicleListAccordingToSelectedPriceRange(searchVehicelListPriceModel.Price).
            Select(x => new VehicleViewModel
            {
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
                price =x.Price
            }).ToList();
        }


        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedOdometerRange")]
        public List<VehicleViewModel> GetVehicleListAccordingToSelectedOdometerRange([FromBody] SearchVehicelListOdometerModel searchVehicelListOdometerModel)
        {

            return _searchRepository.GetVehicleListAccordingToSelectedOdometerRange(searchVehicelListOdometerModel.Odometer).
            Select(x => new VehicleViewModel
            {
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
                price = x.Price
            }).ToList();
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedTransmission")]
        public List<VehicleViewModel> GetVehicleListAccordingToSelectedTransmission([FromBody] SearchVehicelListTransmissionModel searchVehicelListTransmissionModel)
        {
            List<int> transmissionIds = searchVehicelListTransmissionModel.Transmission.Select(tms => tms.Id).ToList();
            return _searchRepository.GetVehicleListAccordingToSelectedTransmission(transmissionIds).
            Select(x => new VehicleViewModel
            {
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
                price = x.Price
            }).ToList();
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedYear")]
        public List<VehicleViewModel> GetVehicleListAccordingToSelectedYear([FromBody] SearchVehicelListYearModel searchVehicelListYearModel)
        {
            List<int> lstYears = searchVehicelListYearModel.Year.Select(y=>y.Id).ToList();
            return _searchRepository.GetVehicleListAccordingToSelectedYear(lstYears).
            Select(x => new VehicleViewModel
            {
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
                price = x.Price
            }).ToList();
        }
    }
}