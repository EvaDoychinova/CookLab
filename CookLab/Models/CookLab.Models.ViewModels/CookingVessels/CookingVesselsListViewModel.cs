namespace CookLab.Models.ViewModels.CookingVessels
{
    using System.Collections.Generic;

    public class CookingVesselsListViewModel : PaginationViewModel
    {
        public IEnumerable<CookingVesselViewModel> CookingVessels { get; set; }
    }
}
