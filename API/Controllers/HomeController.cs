using AutoMapper;
using CarsbyServices.ViewModels;
using Core.Common;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : BaseApiController
    {
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
        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetVehicleTypeListAsync()
        {
            return await _searchRepository.GetVehicleTypeListAsync();
        }

        [HttpGet]
        [Route("GetLocationList")]
        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetLocationListAsync()
        {
            return await _searchRepository.GetLocationListAsync();
        }



        [HttpGet]
        [Route("GetMakeList")]
        public async System.Threading.Tasks.Task<List<getmakeList>> GetMakeListAsync()
        {

            return await _searchRepository.GetMakeListAsync();
        }
        [HttpGet]
        [Route("SideSearchGetMakeList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> SideSearchGetMakeListAsync()
        {
            return await _searchRepository.GetSideSearchMakeListAsync();
        }


        [HttpGet]
        [Route("GetModelList/{makeId}")]
        public async System.Threading.Tasks.Task<List<getmodelList>> GetModelListAsync(int makeId)
        {
            return await _searchRepository.GetModelListAsync(makeId);
        }

        [HttpGet]
        [Route("GetModelListForSideSearch/{makeId}")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetModelListForSideSearchAsync(int makeId)
        {
            return await _searchRepository.GetModelListForSideSearchAsync(makeId);
        }


        [HttpGet]
        [Route("GetVariantListForSideSearch/{modelId}")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetVariantListForSideSearchAsync(int modelId)
        {
            return await _searchRepository.GetVariantListAsync(modelId);
        }


        [HttpGet]
        [Route("GetYearList")]
        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetYearListAsync()
        {
            return await _searchRepository.GetYearListAsync();
        }

        [HttpGet]
        [Route("GetTransmissionList")]
        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetTransmissionListAsync()
        {
            return await _searchRepository.GetTransmissionListAsync();
        }

        [HttpGet]
        [Route("GetCertifiedInspectedList")]
        public List<CommonViewModel> GetCertifiedInspectedList()
        {
            return new List<CommonViewModel>() { new CommonViewModel { Id = 1, Name = "Certified" }, new CommonViewModel { Id = 2, Name = "Inspected" } }; ;
        }



        [HttpPost]
        [Route("GetSearchVehicleList")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetSearchVehicleListAsync([FromBody] SearchViewModel searchViewModel)
        {

            return await _searchRepository.GetSearchVehicleListAsync(searchViewModel);
        }


        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedMakes")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedMakesAsync([FromBody] SelectedMakesListsViewModel selectedMakesListsViewModel)
        {

            List<int> makeIds = selectedMakesListsViewModel.Make.Select(makeId => makeId.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedMakesAsync(makeIds);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedModels")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedModelsAsync([FromBody] SelectedModelsListsViewModel selectedModelsListsViewModel)
        {

            List<int> modelIds = selectedModelsListsViewModel.Model.Select(models => models.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedModelsAsync(modelIds);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedVariants")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedVariantsAsync([FromBody] SelectedVariantsListsViewModel selectedVariantsListsViewModel)
        {

            List<int> variantIds = selectedVariantsListsViewModel.Variant.Select(variant => variant.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedVariantsAsync(variantIds);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedPriceRange")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedPriceRangeAsync([FromBody] SearchVehicleListPriceModel searchVehicleListPriceModel)
        {

            return await _searchRepository.GetVehicleListAccordingToSelectedPriceRangeAsync(searchVehicleListPriceModel.Price);
        }


        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedOdometerRange")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedOdometerRangeAsync([FromBody] SearchVehicleListOdometerModel searchVehicleListOdometerModel)
        {

            return await _searchRepository.GetVehicleListAccordingToSelectedOdometerRangeAsync(searchVehicleListOdometerModel.Odometer);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedTransmission")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedTransmissionAsync([FromBody] SearchVehicleListTransmissionModel searchVehicleListTransmissionModel)
        {
            List<int> transmissionIds = searchVehicleListTransmissionModel.Transmission.Select(tms => tms.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedTransmissionAsync(transmissionIds);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedYear")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedYearAsync([FromBody] SearchVehicleListYearModel searchVehicleListYearModel)
        {
            List<int> lstYears = searchVehicleListYearModel.Year.Select(y => y.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedYearAsync(lstYears);
        }

        [HttpGet]
        [Route("GetFuelTypesList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetFuelTypesListAsync()
        {
                return  await _searchRepository.GetFuelTypesListAsync();
        }

        [HttpGet]
        [Route("GetCylindersList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetCylindersListAsync()
        {
            return await _searchRepository.GetCylindersListAsync();
        }


        [HttpGet]
        [Route("GetEngineSizeList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetEngineSizeListAsync()
        {
            return await _searchRepository.GetEngineSizeListAsync();
        }

        [HttpGet]
        [Route("GetFuelEconomyList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetFuelEconomyListAsync()
        {
            return await _searchRepository.GetFuelEconomyListAsync();
        }

        [HttpGet]
        [Route("GetEngineDescriptionList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetEngineDescriptionListAsync()
        {
            return await _searchRepository.GetEngineDescriptionListAsync();
        }


        [HttpGet]
        [Route("GetColourList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetColourListAsync()
        {
            return await _searchRepository.GetColourListAsync();
        }


        [HttpGet]
        [Route("GetBodyTypeList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetBodyTypeListAsync()
        {
            return await _searchRepository.GetBodyTypeListAsync();
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToVehicleType")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToVehicleTypeAsync([FromBody] SearchVehicleListVehicelTypeModel searchVehicelListVehicleTypeModel)
        {
            List<int> lstVehicleTypeId= searchVehicelListVehicleTypeModel.VehicleType.Select(y => y.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedVehicleTypeAsync(lstVehicleTypeId);
        }


        [HttpPost]
        [Route("GetVehicleListAccordingToFuelType")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToFuelTypeAsync([FromBody] SearchVehicleListFuelTypeModel searchVehicleListFuelTypeModel)
        {
            List<int> lstFuelTypeId = searchVehicleListFuelTypeModel.FuelType.Select(y => y.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedFuelTypeAsync(lstFuelTypeId);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToCylinder")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToCylinderAsync([FromBody] SearchVehicleListCylinderModel searchVehicleListCylinderModel)
        {
            List<int> lstCylinderId = searchVehicleListCylinderModel.Cylinder.Select(y => y.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedCylinderAsync(lstCylinderId);
        }
    }
}