﻿using API.Controllers;
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

namespace CarsbyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddVehicleController : BaseApiController
    {
        private readonly IAddVehicleRepository _addvehiclerepo;
        private readonly IMapper _mapper;
        public AddVehicleController(IAddVehicleRepository addvehiclerepo)
        {
            _addvehiclerepo = addvehiclerepo;
            
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

            var Vehicle = _mapper.Map<VehicleDTO, Vehicle>(VehicleVM);
            return await _addvehiclerepo.AddUpdateNewVehicleAsync(Vehicle);
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
                var desJson= JsonSerializer.Deserialize<IpAddressViewModel>(json);
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
                var response =await client.GetAsync(IpAddressServiceUrl);
                var json = response.Content.ReadAsStringAsync().Result;
                var desJson = JsonSerializer.Deserialize<locationDetails>(json);
                return desJson;
            }
           
        }
    }






}
