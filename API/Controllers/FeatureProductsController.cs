using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeatureProductsController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IFeatureProductsRepository _featureProductsRepository;
        private readonly IImageServiceRepository _imageServiceRepository;
        private readonly ISearchRepository _searchRepository;
        public FeatureProductsController(IFeatureProductsRepository featureProductsRepository,
         IImageServiceRepository imageServiceRepository, ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
            _featureProductsRepository = featureProductsRepository;
            _imageServiceRepository = imageServiceRepository;
        }

        [HttpGet]
        [Route("GetListData")]
        public List<VehicleViewModel> GetListData()
        {
            return _featureProductsRepository.GetProductsList().Select(x => new VehicleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Odometers = x.Odometers,
                RegistrationPlate = x.RegistrationPlate,
                Vin = x.Vin,
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