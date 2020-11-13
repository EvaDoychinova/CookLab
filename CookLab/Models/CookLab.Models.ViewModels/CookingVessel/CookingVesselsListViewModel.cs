namespace CookLab.Models.ViewModels.CookingVessel
{
    using System.Collections.Generic;

    public class CookingVesselsListViewModel
    {
        public IEnumerable<CookingVesselViewModel> CookingVessels { get; set; }
    }
}
