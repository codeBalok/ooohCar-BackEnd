using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using System;

namespace Infrastructure.Services
{
    public class SearchService :ISearchRepository
    {
        private readonly DBContext _dBContext;
        private readonly ISearchRepository _searchRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        public SearchService(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<Location> GetLocationList()
        {
            return _dBContext.Location.ToList();
        }

        public List<Make> GetMakeList()
        {
            return _dBContext.Make.ToList();
        }
        public List<Model> GetModalListCountByID(int id)
        {
            return _dBContext.Model.Where(x=>x.MakeId== id).ToList();
        }

        public List<Variant> GetVarientListCountByID(int id)
        {
            return _dBContext.Variant.Where(x => x.ModelId == id).ToList();
        }
        public List<Model> GetModelList()
        {
            return _dBContext.Model.ToList();
        }
        public List<Variant> GetVariantList()
        {
            return _dBContext.Variant.ToList();
        }

        public List<VehicleType> GetVehicleList()
        {
            return _dBContext.VehicleType.ToList();
        }

        public List<Year> GetYearList()
        {
            return _dBContext.Year.ToList();
        }
        public List<Transmission> GetTransmissionList()
        {
            return _dBContext.Transmission.ToList();
        }
        

        public List<Vehicle> GetSearchVehicleList(string carTypeId, string makeId, string carModelId, string locationId, string yearId){
            List<Vehicle> vehicleList = new List<Vehicle>();
            vehicleList = _dBContext.Vehicle.ToList();
            if (!makeId.Equals("0")){
                List<int> modelIds = _dBContext.Model.Where(x=> x.MakeId == Convert.ToInt64(makeId)).Select(x=> x.Id).ToList();
                vehicleList = vehicleList.Where(x=> modelIds.Contains(x.ModelId ?? 0)).ToList();
            }
            if (!yearId.Equals("0")){
                List<int> yearIds = _dBContext.Model.Where(x=> x.YearId == Convert.ToInt64(yearId)).Select(x=> x.Id).ToList();
                vehicleList = vehicleList.Where(x=> yearIds.Contains(x.ModelId ?? 0)).ToList();
            }

            if (!carTypeId.Equals("0")){
                vehicleList = vehicleList.Where(x=> x.VehicalTypeId == Convert.ToInt64(carTypeId)).ToList();
            }
            if (!carModelId.Equals("0")){
                vehicleList = vehicleList.Where(x=> x.ModelId == Convert.ToInt64(carModelId)).ToList();
            }
            if (!locationId.Equals("0")){
                vehicleList = vehicleList.Where(x=> x.LocationId == Convert.ToInt64(locationId)).ToList();
            }

            return vehicleList;
        }

        public string GetYear(int modelId){
           var yearId = _dBContext.Model.Where(x=> x.Id == modelId).Select(x=> x.YearId).FirstOrDefault();
            return _dBContext.Year.Where(x=> x.Id == yearId).Select(x=> x.Name).FirstOrDefault();
        }
        public string GetBody(int bodyId){
            return _dBContext.BodyType.Where(x=> x.Id == bodyId).Select(x=> x.Name).FirstOrDefault();
        }
        public string GetFuelType(int fuelId){
            return _dBContext.FuelType.Where(x=> x.Id == fuelId).Select(x=> x.Name).FirstOrDefault();
        }
        public string GetTransmission(int transmissionId){
            return _dBContext.Transmission.Where(x=> x.Id == transmissionId).Select(x=> x.Name).FirstOrDefault();
        }
        public string GetCylinders(int cylindersId){
            return _dBContext.Cylinders.Where(x=> x.Id == cylindersId).Select(x=> x.Name).FirstOrDefault();
        }
        public string GetType(int typeId){
            return _dBContext.VehicleType.Where(x=> x.Id == typeId).Select(x=> x.Name).FirstOrDefault();
        }
        
        public List<Vehicle> GetVehicleListAccordingToSelectedMakes(List<int> makeId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (makeId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicle.ToList();
                List<int> modelIds = _dBContext.Model.Where(x => makeId.Contains(x.MakeId)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => modelIds.Contains(x.ModelId ?? 0)).ToList();
            }
            return vehicleList;
        }
        public int GetVehcileCountByMakeID(int makeId)
        {
            List<int> lstmakeId = new List<int>();
            lstmakeId.Add(makeId);
            List<Vehicle> lstVehicle= GetVehicleListAccordingToSelectedMakes(lstmakeId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }
        public int GetVehcileCountByModelID(int modelId)
        {
            List<int> lstmodelId = new List<int>();
            lstmodelId.Add(modelId);
            List<Vehicle> lstVehicle = GetVehicleListAccordingToSelectedModels(lstmodelId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }
        public int GetVehcileCountByVariantID(int variantId)
        {
            List<int> lstvariantId = new List<int>();
            lstvariantId.Add(variantId);
            List<Vehicle> lstVehicle = GetVehicleListAccordingToSelectedVariants(lstvariantId);
            int countVehicle = lstVehicle.Count();
            return countVehicle;
        }
        public List<Vehicle> GetVehicleListAccordingToSelectedModels(List<int> lstmodelId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstmodelId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicle.ToList();               
                List<int> modelIds = _dBContext.Model.Where(x => lstmodelId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => modelIds.Contains(x.ModelId ?? 0)).ToList();
            }
            return vehicleList;
        }
        //public List<Vehicle> GetVehicleListAccordingToSelectedVariant(List<int> lstvariantId)
        //{
        //    List<Vehicle> vehicleList = new List<Vehicle>();
        //    if (lstvariantId.Count() > 0)
        //    {
        //        vehicleList = _dBContext.Vehicle.ToList();
        //        List<int> variantIds = _dBContext.Variant.Where(x => lstvariantId.Contains(x.Id)).Select(x => x.Id).ToList();
        //        vehicleList = vehicleList.Where(x => variantIds.Contains(x.Variant ?? 0)).ToList();
        //    }
        //    return vehicleList;
        //}
        public List<Vehicle> GetVehicleListAccordingToSelectedVariants(List<int> lstvariantId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstvariantId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicle.ToList();
                List<int> variantIds = _dBContext.Variant.Where(x => lstvariantId.Contains(x.Id)).Select(x => x.Id).ToList();
                vehicleList = vehicleList.Where(x => variantIds.Contains(x.Variant ?? 0)).ToList();
            }
            return vehicleList;
        }

        public List<Vehicle> GetVehicleListAccordingToSelectedPriceRange(List<Decimal> lstPrice)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstPrice.Count() > 0)
            {
                vehicleList = _dBContext.Vehicle.ToList();
                vehicleList = vehicleList.Where(l => l.Price>=lstPrice[0] && l.Price<=lstPrice[1]).ToList();
            }
            return vehicleList;

        }
        public List<Vehicle> GetVehicleListAccordingToSelectedOdometerRange(List<int> lstOdometer)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstOdometer.Count() > 0)
            {
                vehicleList = _dBContext.Vehicle.ToList();
                vehicleList = vehicleList.Where(o => Convert.ToInt32(o.Odometers) >= lstOdometer[0] && Convert.ToInt32(o.Odometers) <= lstOdometer[1]).ToList();
            }
            return vehicleList;
        }


        public List<Vehicle> GetVehicleListAccordingToSelectedTransmission(List<int> lstTransmissionId)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            if (lstTransmissionId.Count() > 0)
            {
                vehicleList = _dBContext.Vehicle.ToList();
                vehicleList = vehicleList.Where(t => lstTransmissionId.Contains(t.TransmissionId??00)).ToList();
            }
            return vehicleList;
        }

    }
}