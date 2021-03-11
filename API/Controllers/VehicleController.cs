using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using CarsbyEF.DataContracts;
using CarsbyServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : BaseApiController
    {
        private readonly IAddNewVehicleRepository _addNewVehicle;
        private readonly IMapper _mapper;

        public VehicleController(IAddNewVehicleRepository addNewVehicleRepository, IMapper mapper)
        {
            _addNewVehicle = addNewVehicleRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetBodyTypeList")]
        public List<CommonViewModel> GetBodyTypeList()
        {
            return _addNewVehicle.GetBodyType().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        [HttpGet]
        [Route("GetCategoryList")]
        public List<CommonViewModel> GetCategoryList()
        {
            return _addNewVehicle.GetCategory().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        [HttpGet]
        [Route("GetFualTypeList")]
        public List<CommonViewModel> GetFualTypeList()
        {
            return _addNewVehicle.GetFualType().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        [HttpGet]
        [Route("GetTransmissionList")]
        public List<CommonViewModel> GetTransmissionList()
        {
            return _addNewVehicle.GetTransmission().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        [HttpGet]
        [Route("GetCylindersList")]
        public List<CommonViewModel> GetCylindersList()
        {
            return _addNewVehicle.GetCylinders().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        [HttpGet]
        [Route("GetFualEconomyList")]
        public List<CommonViewModel> GetFualEconomyList()
        {
            return _addNewVehicle.GetFualEconomy().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        [HttpGet]
        [Route("GetEngineDescriptionList")]
        public List<CommonViewModel> GetEngineDescriptionList()
        {
            return _addNewVehicle.GetEngineDescription().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        [HttpGet]
        [Route("GetEngineSizeList")]
        public List<CommonViewModel> GetEngineSizeList()
        {
            return _addNewVehicle.GetEngineSize().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        [HttpGet]
        [Route("GetVariantList/{modalId}")]
        public List<CommonViewModel> GetVariantList(int modalId)
        {
            return _addNewVehicle.GetVariant(modalId).Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Varient
            }).ToList();
        }
        [HttpGet]
        [Route("GetConditionList")]
        public List<CommonViewModel> GetConditionList()
        {
            return _addNewVehicle.GetCondition().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Condition1
            }).ToList();
        }
        [HttpGet]
        [Route("GetPriceList")]
        public List<CommonViewModel> GetPriceList()
        {
            return _addNewVehicle.GetPrice().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Amount.ToString()
            }).ToList();
        }
        [HttpGet]
        [Route("GetColor")]
        public List<CommonViewModel> GetColor()
        {
            return _addNewVehicle.GetColor().Select(x => new CommonViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        [HttpPost]
        [Route("AddUpdateNewVehicle")]
        public string AddUpdateNewVehicle([FromForm] VehicleDTO VehicleVM)
        {
            
            var Vehicle = _mapper.Map<VehicleDTO, Vehicle>(VehicleVM);
            return _addNewVehicle.AddUpdateNewVehicle(Vehicle);
        }


    }
}
