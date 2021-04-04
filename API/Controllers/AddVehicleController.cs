using API.Controllers;
using API.Dtos;
using AutoMapper;
using CarsbyServices.Interfaces;
using CarsbyServices.ViewModels;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsbyEF.DataContracts;
using System.Net.Http;
using CarsbyServices.ViewModel;
using System.Text.Json;
using System.IO;

namespace CarsbyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddVehicleController : BaseApiController
    {
        private readonly IAddVehicleRepository _addvehiclerepo;
        private readonly IMapper _mapper;
        private readonly IImageWriterService _imageWriterService;
        private readonly IVehicleImageRepository _imageRepository;
        public AddVehicleController(IAddVehicleRepository addvehiclerepo, IImageWriterService imageWriterService, IVehicleImageRepository imageRepository)
        {
            _addvehiclerepo = addvehiclerepo;
            _imageWriterService = imageWriterService;
            _imageRepository = imageRepository;
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

        [HttpGet]
        [Route("GetVarientList/{modelId}")]
        public async System.Threading.Tasks.Task<List<getvarientList>> GetVarientListAsync(int modelId)
        {
            return await _addvehiclerepo.GetVarientListAsync(modelId);
        }

        [HttpGet]
        [Route("GetFuelTypesList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetFuelTypesListAsync()
        {
            return await _addvehiclerepo.GetFuelTypesListAsync();
        }

        [HttpGet]
        [Route("GetYearList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetYearListAsync()
        {
            return await _addvehiclerepo.GetYearListAsync();
        }
        [HttpGet]
        [Route("GetConditionList")]
        public async System.Threading.Tasks.Task<List<ConditionViewModel>> GetConditionListAsync()
        {
            return await _addvehiclerepo.GetConditionListAsync();
        }
        [HttpGet]
        [Route("GetPriceList")]
        public async System.Threading.Tasks.Task<List<PriceViewModel>> GetPriceListAsync()
        {
            return await _addvehiclerepo.GetPriceListAsync();
        }

        [HttpGet]
        [Route("GetTrasmissionList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetTrasmissionListAsync()
        {
            return await _addvehiclerepo.GetTrasmissionListAsync();
        }
        [HttpGet]
        [Route("GetCylindersList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetCylindersListAsync()
        {
            return await _addvehiclerepo.GetCylindersListAsync();
        }
        [HttpGet]
        [Route("GetBodyTypeList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetBodyTypeListAsync()
        {
            return await _addvehiclerepo.GetBodyTypeListAsync();
        }

        [HttpGet]
        [Route("GetColourList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetColourListAsync()
        {
            return await _addvehiclerepo.GetColourListAsync();
        }
        [HttpPost]
        [Route("AddUpdateNewVehicle")]
        public async System.Threading.Tasks.Task<string> AddUpdateNewVehicle([FromForm] VehicleDTO VehicleVM)
        {
            try
            {
        
                VehicleVM.CreatedDate = DateTime.Now;
                VehicleVM.CreatedBy = 1; //static pass need to discuss how we can make it dynamic ? client query  
                if (VehicleVM.RegistrationPlate != null)
                {
                    VehicleVM.IsRegistered = "Yes";
                }
                else
                {
                    VehicleVM.IsRegistered = "No";
                }
                int intmakeid = Convert.ToInt32(VehicleVM.MakeId);
                int intmodelid = Convert.ToInt32(VehicleVM.ModelId);
                string makename = await _addvehiclerepo.GetMakeNameById(intmakeid);
                string modelname = await _addvehiclerepo.GetModelNameById(intmodelid);
                string getVechileName= makename + " " + modelname;
                getVechileName = getVechileName.ToUpper();
                VehicleVM.Name = getVechileName; //is this based on make model or should we pass this? client query
                //var Vehicle = _mapper.Map<VehicleDTO, Vehicle>(VehicleVM);
                Vehicle objvehicle = new Vehicle();
                objvehicle.AirConditioning = VehicleVM.AirConditioning;
                objvehicle.AuctionGrade = VehicleVM.AuctionGrade;
                objvehicle.BodyTypeId =Convert.ToInt32(VehicleVM.BodyTypeId);
                objvehicle.City = VehicleVM.City;
                objvehicle.ColourId =Convert.ToInt32(VehicleVM.ColourId);
                objvehicle.CreatedBy = VehicleVM.CreatedBy;
                objvehicle.CreatedDate = VehicleVM.CreatedDate;
                objvehicle.CylindersId =Convert.ToInt32(VehicleVM.CylindersId);
                objvehicle.DriveTrain = VehicleVM.DriveTrain;
                objvehicle.IsRegistered = VehicleVM.IsRegistered;
                objvehicle.RegistrationPlate = VehicleVM.RegistrationPlate;
                objvehicle.FuelTypeId =Convert.ToInt32(VehicleVM.FuelTypeId);
                objvehicle.Kilometer =Convert.ToInt32( VehicleVM.Kilometer);
                objvehicle.Latitude = VehicleVM.Latitude;
                objvehicle.Longitude = VehicleVM.Longitude;
                objvehicle.MakeId =Convert.ToInt32(VehicleVM.MakeId);
                objvehicle.ModelId =Convert.ToInt32(VehicleVM.ModelId);
                objvehicle.Vin = VehicleVM.Vin;
                objvehicle.TransmissionId = Convert.ToInt32(VehicleVM.TransmissionId);
                objvehicle.Odometers =VehicleVM.Odometers;
                objvehicle.Name = VehicleVM.Name;
                objvehicle.Price =Convert.ToDecimal(VehicleVM.PriceId);
                objvehicle.IsActive = true;
                objvehicle.YearId =Convert.ToInt32(VehicleVM.YearId);
                objvehicle.ConditionId = Convert.ToInt32(VehicleVM.ConditionId);
                objvehicle.Description = VehicleVM.description;
                string vehicleId = await _addvehiclerepo.AddUpdateNewVehicleAsync(objvehicle);

                foreach (var formFile in VehicleVM.VehicleImage)
                {

                    if (formFile.Length > 0)
                    {
                        var ImagePath = await _imageWriterService.UploadImage(formFile);
                        string imagePath = ImagePath;
                        int imageid = await _imageRepository.SaveVehicleImage(imagePath, Convert.ToInt32(vehicleId));

                    }
                }
                return "Success";
            }
            catch (NullReferenceException e)
            {
                return e.InnerException.ToString();
            }
        }

        [HttpGet]
        [Route("GetEngineSizeList")]
        public async System.Threading.Tasks.Task<List<SideSearchCommonViewModel>> GetEngineSizeListAsync()
        {
            return await _addvehiclerepo.GetEngineSizeListAsync();
        }

        [HttpGet]
        [Route("GetIpAddress")]
        public async System.Threading.Tasks.Task<IpAddressViewModel> GetIpAddressAsync()
        {
            string returnIpAddress = string.Empty;
            string IpAddressServiceUrl = "http://api.ipify.org/?format=json";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(IpAddressServiceUrl);
                var json = response.Content.ReadAsStringAsync().Result;
                var desJson = JsonSerializer.Deserialize<IpAddressViewModel>(json);
                return desJson;
            }

        }

        [HttpGet]
        [Route("GetLocationByIp/{ip}")]
        public async System.Threading.Tasks.Task<locationDetails> GetLocationByIpAsync(string ip)
        {
            string returnIpAddress = string.Empty;
            string IpAddressServiceUrl = "http://ip-api.com/json/" + ip;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(IpAddressServiceUrl);
                var json = response.Content.ReadAsStringAsync().Result;
                var desJson = JsonSerializer.Deserialize<locationDetails>(json);
                return desJson;
            }

        }
    }






}
