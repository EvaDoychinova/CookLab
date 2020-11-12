namespace CookLab.Models.InputModels.CookingVessel
{
    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;
    using CookLab.Services.Mapping;

    public class CookingVesselInputModel
    {
        public PanForm Form { get; set; }

        public virtual VesselDimensionInputModel VesselDimension { get; set; }

        public double Volume { get; set; }
    }
}
