namespace CookLab.Data.Models
{
    using CookLab.Data.Common.Models;
    using CookLab.Data.Models.Enums;

    public class CookingVessel : BaseModel<int>
    {
        public PanForm Form { get; set; }

        public virtual VesselDimension VesselDimension { get; set; }

        public double Volume { get; set; }
    }
}
