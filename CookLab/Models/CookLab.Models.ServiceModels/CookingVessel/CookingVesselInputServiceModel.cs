namespace CookLab.Models.ServiceModels.CookingVessel
{
    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;
    using CookLab.Services.Mapping;

    public class CookingVesselInputServiceModel : IMapTo<CookingVessel>
    {
        public PanForm Form { get; set; }

        public virtual VesselDimensionInputServiceModel VesselDimension { get; set; }

        public double Volume { get; set; }
    }
}
