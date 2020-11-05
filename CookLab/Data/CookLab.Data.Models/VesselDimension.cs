namespace CookLab.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    public class VesselDimension : BaseModel<int>
    {
        public VesselDimension()
        {
            this.Diameter = 1;
            this.SideA = 1;
            this.SideB = 1;
            this.Height = 1;
        }

        public double Diameter { get; set; }

        public double SideA { get; set; }

        public double SideB { get; set; }

        public double Height { get; set; }

        [Required]
        [ForeignKey(nameof(CookingVessel))]
        public int CookingVesselId { get; set; }

        public virtual CookingVessel CookingVessel { get; set; }
    }
}
