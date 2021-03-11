using System.Collections.Generic;

namespace CarsbyServices.ViewModels
{
    public partial class CommonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public partial class getmodelList
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Popular { get; set; }
    }

    public partial class getmakeList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoImages { get; set; }
    }
    public partial class getvarientList
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
    }
    public partial class SideSearchCommonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChildCount { get; set; }
    }
    public partial class ConditionViewModel
    {
        public int Id { get; set; }
        public string Condition { get; set; }
       
    }
    public partial class PriceViewModel
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }

    }
    public partial class SearchMakeViewModel : CommonViewModel
    {
        public int Count { get; set; }
    }

    public partial class SearchVehicleListPriceModel
    {
        public List<decimal> Price { get; set; }
    }
    public partial class SearchVehicleListOdometerModel
    {
        public List<int> Odometer { get; set; }
    }
    public partial class SearchVehicleListTransmissionModel
    {
        public List<CommonViewModel> Transmission { get; set; }
    }
    public partial class SearchVehicleListYearModel
    {
        public List<CommonViewModel> Year { get; set; }
    }

    public partial class SearchVehicleListVehicleTypeModel
    {
        public List<CommonViewModel> VehicleType { get; set; }
    }

    public partial class SearchVehicleListFuelTypeModel
    {
        public List<CommonViewModel> FuelType { get; set; }
    }

    public partial class SearchVehicleListCylinderModel
    {
        public List<CommonViewModel> Cylinder { get; set; }
    }
    public partial class SearchVehicleListEngineSizeModel
    {
        public List<CommonViewModel> EngineSize { get; set; }
    }
    public partial class SearchVehicleListEngineDescriptionModel
    {
        public CommonViewModel EngineDescription { get; set; }
    }
    public partial class SearchVehicleListFuelEconomyModel
    {
        public CommonViewModel FuelEconomy { get; set; }
    }
    public partial class SearchVehicleListInductionTurboModel
    {
        public CommonViewModel InductionTurbo { get; set; }
    }
    public partial class SearchVehicleListPowerModel
    {
        public List<CommonViewModel> Power { get; set; }
    }
    public partial class SearchVehicleListPowerToWeightModel
    {
        public List<CommonViewModel> PowerToWeight { get; set; }
    }
    public partial class SearchVehicleListTowModel
    {
        public List<CommonViewModel> Tow { get; set; }
    }
    public partial class SearchVehicleListDriveTypeModel
    { 
      public CommonViewModel DriveType { get; set; } 
    }
    public partial class SearchVehicleListBodyTypeModel
    {
        public List<CommonViewModel> BodyType { get; set; }
    }
    public partial class SearchVehicleListColourModel
    {
        public List<CommonViewModel> Colour { get; set; }
    }
    public partial class SearchVehicleListSeatModel
    {
        public List<CommonViewModel> Seat { get; set; }
    }

    public partial class SearchVehicleListLifeStylesModel
    {
        public CommonViewModel LifeStyles { get; set; }
    }

    public partial class SearchVehicleListDoorsModel
    {
        public CommonViewModel Doors { get; set; }
    }
    public partial class SearchVehicleListCertifiedInspectedModel
    {
        public List<CommonViewModel> CertifiedInspected { get; set; }
    }

}
