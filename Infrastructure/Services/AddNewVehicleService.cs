using Core.Interfaces;
using CarsbyEF.DataContracts;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class AddNewVehicleService : IAddNewVehicleRepository
    {
        private readonly CarBuyContext _dBContext;

        public AddNewVehicleService(CarBuyContext dBContext)
        {
            _dBContext = dBContext;
        }
        public List<EngineDescription> GetEngineDescription()
        {
            return _dBContext.EngineDescriptions.ToList();
        }

        public List<EngineSize> GetEngineSize()
        {
            return _dBContext.EngineSizes.ToList();
        }

        public List<FuelEconomy> GetFualEconomy()
        {
            return _dBContext.FuelEconomies.ToList();
        }

        public List<FuelType> GetFualType()
        {
            return _dBContext.FuelTypes.ToList();
        }

        public List<BodyType> GetBodyType()
        {
            return _dBContext.BodyTypes.ToList();
        }

        public List<Category> GetCategory()
        {
            return _dBContext.Categories.ToList();
        }

        public List<Cylinder> GetCylinders()
        {
            return _dBContext.Cylinders.ToList();
        }

        public List<Transmission> GetTransmission()
        {
            return _dBContext.Transmissions.ToList();
        }


        public List<Condition> GetCondition()
        {
            return _dBContext.Conditions.ToList();
        }
        public List<Price> GetPrice()
        {
            return _dBContext.Prices.ToList();
        }

        public List<Variant> GetVariant(int id)
        {
            return _dBContext.Variants.Where(x => x.ModelId == id).ToList();
        }
        public List<Colour> GetColor()
        {
            return _dBContext.Colours.ToList();
        }

        public string AddUpdateNewVehicle(Vehicle objvehicleToSave)
        {
            if (objvehicleToSave != null)
            {
                if (objvehicleToSave.Id == 0)
                {
                    _dBContext.Vehicles.Add(objvehicleToSave);
                    _dBContext.SaveChanges();
                    return "added";
                }
                else
                {
                    _dBContext.Vehicles.Where(a => a.Id == objvehicleToSave.Id).FirstOrDefault();
                    _dBContext.Vehicles.Update(objvehicleToSave);
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
