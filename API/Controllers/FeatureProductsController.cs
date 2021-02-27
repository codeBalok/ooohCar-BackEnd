using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using CarsbyServices.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetListDataAsync()
        {
            return await _featureProductsRepository.GetProductsListAsync();
        }
    }
}