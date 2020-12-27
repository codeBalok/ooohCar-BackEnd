using System;
using System.Collections.Generic;

namespace Infrastructure.ViewModels
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
    }
}
