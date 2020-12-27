using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface  IAddNewVehicleRepository
    {
        List<BodyType> GetBodyType();
        List<Category> GetCategory();
        List<FuelType> GetFualType();
        List<Transmission> GetTransmission();
        List<Cylinders> GetCylinders();
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
