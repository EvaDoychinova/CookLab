namespace CookLab.Models.ServiceModels.CookingVessels
{
    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;
    using CookLab.Models.ServiceModels.VesselDimensions;
    using CookLab.Services.Mapping;

    public class CookingVesselPerRecipeServiceModel : IMapFrom<CookingVessel>
    {
        public PanForm Form { get; set; }

        public string FormToString => this.Form.ToString();

        public virtual VesselDimensionPerRecipeServiceModel VesselDimension { get; set; }
    }
}
