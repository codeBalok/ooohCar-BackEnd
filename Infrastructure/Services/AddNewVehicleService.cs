using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class AddNewVehicleService : IAddNewVehicleRepository
    {
        private readonly DBContext _dBContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddNewVehicleRepository _addNewVehicle;
        public AddNewVehicleService(DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public List<EngineDescription> GetEngineDescription()
        {
            return _dBContext.EngineDescription.ToList();
        }

        public List<EngineSize> GetEngineSize()
        {
            return _dBContext.EngineSize.ToList();
        }

        public List<FuelEconomy> GetFualEconomy()
        {
            return _dBContext.FuelEconomy.ToList();
        }

        public List<FuelType> GetFualType()
        {
            return _dBContext.FuelType.ToList();
        }

        public List<BodyType> GetBodyType()
        {
            return _dBContext.BodyType.ToList();
        }

        public List<Category> GetCategory()
        {
            return _dBContext.Category.ToList();
        }

        public List<Cylinders> GetCylinders()
        {
            return _dBContext.Cylinders.ToList();
        }

        public List<Transmission> GetTransmission()
        {
            return _dBContext.Transmission.ToList();
        }


        public List<Condition> GetCondition()
        {
            return _dBContext.Condition.ToList();
        }
        public List<Price> GetPrice()
        {
            return _dBContext.Price.ToList();
        }

        public List<Variant> GetVariant(int id)
        {
            return _dBContext.Variant.Where(x => x.ModelId == id).ToList();
        }
        public List<Colour> GetColor()
        {
            return _dBContext.Colour.ToList();
        }

        public string AddUpdateNewVehicle(Vehicle objvehicleToSave)
        {
            if (objvehicleToSave != null)
            {
                if (objvehicleToSave.Id == 0)
                {
                    _dBContext.Vehicle.Add(objvehicleToSave);
                    _dBContext.SaveChanges();
                    return "added";
                }
                else
                {
                    _dBContext.Vehicle.Where(a => a.Id == objvehicleToSave.Id).FirstOrDefault();
                    _dBContext.Vehicle.Update(objvehicleToSave);
                    _dBContext.SaveChanges();
                    return "updated";
                }
            }
            else
            {
                return null;
            }
        }
    }
}
