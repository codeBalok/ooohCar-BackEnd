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
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetVehicleTypeListAsync()
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
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetCertifiedInspectedList()
        {
            //return new List<SideSearchCommonViewModel>() { new SideSearchCommonViewModel { Id = 1, Name = "Certified" }, new SideSearchCommonViewModel { Id = 2, Name = "Inspected" } }; ;
            return await _searchRepository.GetCertifiedInspectedListAsync();
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
            return await _searchRepository.GetFuelTypesListAsync();
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
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToVehicleTypeAsync([FromBody] SearchVehicleListVehicleTypeModel searchVehicleListVehicleTypeModel)
        {
            List<int> lstVehicleTypeId = searchVehicleListVehicleTypeModel.VehicleType.Select(y => y.Id).ToList();
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

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedEngineSize")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedEngineSize([FromBody] SearchVehicleListEngineSizeModel searchVehicleListEngineSizeModel)
        {
            List<int> lstEngineSizeId = searchVehicleListEngineSizeModel.EngineSize.Select(e => e.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedEngineSizeAsync(lstEngineSizeId);
        }
        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedEngineDescription")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedEngineDescription([FromBody] SearchVehicleListEngineDescriptionModel searchVehicleListEngineDescriptionModel)
        {
            int engineDescriptionId = searchVehicleListEngineDescriptionModel.EngineDescription.Id;
            return await _searchRepository.GetVehicleListAccordingToSelectedEngineDescriptionAsync(engineDescriptionId);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedFuelEconomy")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedFuelEconomy([FromBody] SearchVehicleListFuelEconomyModel searchVehicleListFuelEconomyModel)
        {
            int fuelEconomyId = searchVehicleListFuelEconomyModel.FuelEconomy.Id;
            return await _searchRepository.GetVehicleListAccordingToSelectedFuelEconomyAsync(fuelEconomyId);
        }
        [HttpGet]
        [Route("GetInductionTurboList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetInductionTurboList()
        {
            return await _searchRepository.GetInductionTurboListAsync();
        }

        [HttpGet]
        [Route("GetPowerList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetPowerList()
        {
            return await _searchRepository.GetPowerListAsync();
        }

        [HttpGet]
        [Route("GetPowerToWeightList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetPowerToWeightList()
        {
            return await _searchRepository.GetPowerToWeightListAsync();
        }

        [HttpGet]
        [Route("GetTowList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetTowList()
        {
            return await _searchRepository.GetTowListAsync();
        }
        [HttpGet]
        [Route("GetDriveTypeList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetDriveTypeList()
        {
            return await _searchRepository.GetDriveTypeListAsync();
        }
        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedInductionTurbo")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedInductionTurbo([FromBody] SearchVehicleListInductionTurboModel searchVehicleListInductionTurboModel)
        {
            int InductionTurboId = searchVehicleListInductionTurboModel.InductionTurbo.Id;
            return await _searchRepository.GetVehicleListAccordingToSelectedInductionTurboAsync(InductionTurboId);
        }
        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedPower")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedPowerAsync([FromBody] SearchVehicleListPowerModel searchVehicleListPowerModel)
        {
            List<int> lstPowers = searchVehicleListPowerModel.Power.Select(y => y.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedPowersAsync(lstPowers);
        }
        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedPowerToWeight")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedPowerToWeightAsync([FromBody] SearchVehicleListPowerToWeightModel searchVehicleListPowerToWeightModel)
        {
            List<int> lstPowerToWeights = searchVehicleListPowerToWeightModel.PowerToWeight.Select(y => y.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedPowerToWeightsAsync(lstPowerToWeights);
        }
        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedTow")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedTowAsync([FromBody] SearchVehicleListTowModel searchVehicleListTowModel)
        {
            List<int> lstTows = searchVehicleListTowModel.Tow.Select(y => y.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedTowsAsync(lstTows);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedDriveType")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedDriveTypeAsync([FromBody] SearchVehicleListDriveTypeModel searchVehicleListDriveTypeModel)
        {
            int driveTypeId = searchVehicleListDriveTypeModel.DriveType.Id;
            return await _searchRepository.GetVehicleListAccordingToSelectedDriveTypeAsync(driveTypeId);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedBodyType")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedBodyTypeAsync([FromBody] SearchVehicleListBodyTypeModel searchVehicleListBodyTypeModel)
        {
            List<int> BodyTypeIds = searchVehicleListBodyTypeModel.BodyType.Select(bdtype => bdtype.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedBodyTypeAsync(BodyTypeIds);
        }
        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedColour")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedColourAsync([FromBody] SearchVehicleListColourModel searchVehicleListColourModel)
        {
            List<int> ColourIds = searchVehicleListColourModel.Colour.Select(clr => clr.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedColourAsync(ColourIds);
        }

        [HttpGet]
        [Route("GetPriceList")]
        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetPriceListAsync()
        {
            return await _searchRepository.GetPriceListAsync();
        }

        [HttpGet]
        [Route("GetLifeStylesList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetLifeStylesAsyn()
        {
            return await _searchRepository.GetLifeStylesListAsync();
        }
        [HttpGet]
        [Route("GetDoorsList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetDoorsAsyn()
        {
            return await _searchRepository.GetDoorsListAsync();
        }
        [HttpGet]
        [Route("GetSeatsList")]
        public async System.Threading.Tasks.Task<List<CommonViewModel>> GetSeatsAsync()
        {
            return await _searchRepository.GetSeatsListAsync();
        }


        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedSeat")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedSeatAsync([FromBody] SearchVehicleListSeatModel searchVehicleListSeatModel)
        {
            List<int> SeatIds = searchVehicleListSeatModel.Seat.Select(st => st.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedSeatsAsync(SeatIds);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedLifeStyles")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedLifeStylesAsync([FromBody] SearchVehicleListLifeStylesModel searchVehicleListLifeStylesModel)
        {
            int lifeStylesId = searchVehicleListLifeStylesModel.LifeStyles.Id;
            return await _searchRepository.GetVehicleListAccordingToSelectedLifeStylesAsync(lifeStylesId);
        }

        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedDoors")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedDoorsAsync([FromBody] SearchVehicleListDoorsModel searchVehicleListDoorsModel)
        {
            int doorId = searchVehicleListDoorsModel.Doors.Id;
            return await _searchRepository.GetVehicleListAccordingToSelectedDoorsAsync(doorId);
        }
        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedVehicleType")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedVehicelTypeAsync([FromBody] SearchVehicleListVehicleTypeModel searchVehicleListVehicleTypeModel)
        {
            List<int> lstVehicelTypes = searchVehicleListVehicleTypeModel.VehicleType.Select(y => y.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedVehicelTypeAsync(lstVehicelTypes);
        }
        [HttpPost]
        [Route("GetVehicleListAccordingToSelectedCertifiedInspected")]
        public async System.Threading.Tasks.Task<List<VehicleViewModel>> GetVehicleListAccordingToSelectedCertifiedInspectedAsync([FromBody] SearchVehicleListCertifiedInspectedModel searchVehicleListCertifiedInspectedModel)
        {
            List<int> CertifiedInspectedIds = searchVehicleListCertifiedInspectedModel.CertifiedInspected.Select(clr => clr.Id).ToList();
            return await _searchRepository.GetVehicleListAccordingToSelectedCertifiedInspectedAsync(CertifiedInspectedIds);
        }

    }
}