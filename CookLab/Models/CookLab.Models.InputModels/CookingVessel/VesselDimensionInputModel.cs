namespace CookLab.Models.InputModels.CookingVessel
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class VesselDimensionInputModel : IMapTo<VesselDimension>
    {
        public double Diameter { get; set; }

        public double SideA { get; set; }

        public double SideB { get; set; }

        public double Height { get; set; }
    }
}
