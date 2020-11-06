namespace CookLab.Models.ServiceModels.VesselDimensions
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class VesselDimensionPerRecipeServiceModel : IMapFrom<VesselDimension>
    {
        public double Diameter { get; set; }

        public double SideA { get; set; }

        public double SideB { get; set; }

        public double Height { get; set; }
    }
}
