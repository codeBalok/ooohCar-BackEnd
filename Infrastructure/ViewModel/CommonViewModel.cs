using System;
using System.Collections.Generic;

namespace Infrastructure.ViewModels
{
    public partial class CommonViewModel
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
    public partial class SearchMakeViewModel : CommonViewModel
    {
        public int Count { get; set; }
    }

    public partial class SearchVehicelListPriceModel 
    {
        public List<decimal> Price { get; set; }
    }
    public partial class SearchVehicelListOdometerModel
    {
        public List<int> Odometer { get; set; }
    }
    public partial class SearchVehicelListTransmissionModel
    {
        public List<CommonViewModel> Transmission { get; set; }
    }
}
