using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Odometers { get; set; }
        public int BodyTypeId { get; set; }
        public string Vin { get; set; }
        public int? ModelId { get; set; } 
        public int? PriceId { get; set; }
        public int? CategoryId { get; set; }
        public string RegistrationPlate { get; set; }
        public int? VehicalTypeId { get; set; }
        public int? LocationId { get; set; }
        public int? FuelTypeId { get; set; }
        public int? TransmissionId { get; set; }
        public int? CylindersId { get; set; }
        public int? FuelEconomyId { get; set; }
        public int? EngineDescriptionId { get; set; }
        public int? MakeId { get; set; }  
        public int? Variant { get; set; }
        public int? ConditionId { get; set; } 
        public int? Kilometer { get; set; }
        public int? EngineSizeId { get; set; }
        public string AirConditioning { get; set; }
        public string AuctionGrade { get; set; }
        public string DriveTrain { get; set; }
        public string IsRegistered { get; set; }
        public int? ColourId { get; set; }
        public int? SellerTypeId { get; set; }
        public int? VehicleCategoryId { get; set; }
        public int? VehicleImageId { get; set; }
        public int? YearId { get; set; } 
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual BodyType BodyType { get; set; }
        public virtual Category Category { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual Cylinders Cylinders { get; set; }
        public virtual EngineDescription EngineDescription { get; set; }
        public virtual EngineSize EngineSize { get; set; }
        public virtual FuelEconomy FuelEconomy { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Location Location { get; set; }
        public virtual Make Make { get; set; }
        public virtual Model Model { get; set; }
        public virtual SellerType SellerType { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual Variant VariantNavigation { get; set; }
        public virtual VehicleType VehicalType { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }
        public virtual VehicleImage VehicleImage { get; set; }
        public virtual Year Year { get; set; }
    }
}
