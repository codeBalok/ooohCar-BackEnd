using System.Collections.Generic;

namespace CarsbyServices.ViewModels
{
    public partial class SearchListsViewModel
    {
        public List<CommonViewModel> CarType { get; set; }
        public List<CommonViewModel> Make { get; set; }
        public List<CommonViewModel> CarModel { get; set; }
        public List<CommonViewModel> Location { get; set; }
        public List<CommonViewModel> Year { get; set; }
    }

    public partial class SearchViewModel
    {
        public string CarTypeId { get; set; }
        public string MakeId { get; set; }
        public string CarModelId { get; set; }
        public string LocationId { get; set; }
        public string YearId { get; set; }
        public string UserId { get; set; }
    }
    public partial class SelectedMakesListsViewModel
    {
        public List<SideSearchCommonViewModel> Make { get; set; }
    }
    public partial class SelectedModelsListsViewModel
    {
        public List<SideSearchCommonViewModel> Model { get; set; }
    }
    public partial class SelectedVariantsListsViewModel
    {
        public List<SideSearchCommonViewModel> Variant { get; set; }
    }
    public partial class SelectedPriceListsViewModel
    {
        public SearchVehicelListPriceModel Prices { get; set; }
    }
}
