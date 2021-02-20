using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class VehicleDTO
    {
		public string Id { get; set; }	
		public string Name { get; set; }
		public string Odometers { get; set; }
		public string MakeId { get; set; }
		public string ModelId { get; set; }
		public string YearId { get; set; }
		public string Variant { get; set; }
		public string ConditionId { get; set; }
		public string PriceId { get; set; }
		public string Kilometer { get; set; }
		public string TransmissionId { get; set; }
		public string FuelTypeId { get; set; }
		public string DriveTrain { get; set; }
		public string CylindersId { get; set; }
		public string BodyTypeId { get; set; }
		public string ColourId { get; set; }
		public string AirConditioning { get; set; }
		public string AuctionGrade { get; set; }
		public string LocationId { get; set; }
		public string VehicleImageId { get; set; }
		public IFormFile VehicleImage { get; set; }
		public string Base64Image { get; set; }
		public string Vin { get; set; }
		public int? CategoryId { get; set; }
		public string RegistrationPlate { get; set; }
		public int? VehicalTypeId { get; set; }
		public int? EngineDescriptionId { get; set; }
		public int? EngineSizeId { get; set; }
		public string IsRegistered { get; set; }
		public int? SellerTypeId { get; set; }
		public int? VehicleCategoryId { get; set; }
		public bool? IsActive { get; set; }
		public int CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public int? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}

}
