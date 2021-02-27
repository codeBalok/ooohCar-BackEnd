using CarsbyEF.DataContracts;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IAddNewVehicleRepository
    {
        List<BodyType> GetBodyType();
        List<Category> GetCategory();
        List<FuelType> GetFualType();
        List<Transmission> GetTransmission();
        List<Cylinder> GetCylinders();
        List<FuelEconomy> GetFualEconomy();
        List<EngineDescription> GetEngineDescription();
        List<EngineSize> GetEngineSize();
        List<Price> GetPrice();
        List<Colour> GetColor();
        List<Condition> GetCondition();
        List<Variant> GetVariant(int id);

        string AddUpdateNewVehicle(Vehicle objvehicleToSave);


    }
}
