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
    public partial class SideSearchCommonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChildCount { get; set; }
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

    public partial class SearchVehicleListVehicelTypeModel
    {
        public List<CommonViewModel> VehicleType { get; set; }
    }

    public partial class SearchVehicleListFuelTypeModel
    {
        public List<CommonViewModel>  FuelType { get; set; }
    }

    public partial class SearchVehicleListCylinderModel
    {
        public List<CommonViewModel> Cylinder { get; set; }
    }
}
