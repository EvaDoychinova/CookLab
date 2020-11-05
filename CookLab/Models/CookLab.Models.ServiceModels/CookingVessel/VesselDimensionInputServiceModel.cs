namespace CookLab.Models.ServiceModels.CookingVessel
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class VesselDimensionInputServiceModel : IMapTo<VesselDimension>
    {
        public double Diameter { get; set; }

        public double SideA { get; set; }

        public double SideB { get; set; }

        public double Height { get; set; }
    }
}
