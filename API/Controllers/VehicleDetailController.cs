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
using CarsbyServices.Common;

namespace CarsbyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VechileDetailController : BaseApiController
    {
        private readonly ICarDetailRepository _vehicleDetailrepo;
        private readonly IMapper _mapper;
        
        public VechileDetailController(ICarDetailRepository vechileDetailrepo)
        {
            _vehicleDetailrepo = vechileDetailrepo;
           
        }

        [HttpGet]
        [Route("GetVehicleDetail/{vehicleId}")]
        public async System.Threading.Tasks.Task<VehicleDetail> GetVehicleDetailbyIdAsync(string vehicleid)
       {
            int vechileidInt = Convert.ToInt32(vehicleid);
            var Vechile = await _vehicleDetailrepo.GetVehicleDetailbyIdAsync(vechileidInt );
            CarsbyServices.ViewModel.Mapper _mapperForConversion = new CarsbyServices.ViewModel.Mapper(_vehicleDetailrepo);
            VehicleDetail objVehicleDetail = await _mapperForConversion.MapVehicleDetailWithVehicleDetail(Vechile);
            for (int i = 0; i < objVehicleDetail.VehileImage.Count; i++)
            {
                string convertintobase64= Utility.ByteToBase64(objVehicleDetail.VehileImage[i]);
                objVehicleDetail.VehileImage[i] = convertintobase64;
            }
            return objVehicleDetail;
        }
    }
}
