namespace CookLab.Models.InputModels.CookingVessel
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models.Enums;

    using static CookLab.Common.ModelsValidations.CookingVesselValidations;

    public class CookingVesselInputModel
    {
        public string Name { get; set; }

        public PanForm Form { get; set; }

        [Range(DiameterMinValue, DiameterMaxValue)]
        public double? Diameter { get; set; }

        [Range(SideMinValue, SideMaxValue)]
        public double? SideA { get; set; }

        [Range(SideMinValue, SideMaxValue)]
        public double? SideB { get; set; }

        [Required]
        [Range(HeightMinValue, HeightMaxValue)]
        public double Height { get; set; }

        [Range(VolumeMinValue, VolumeMaxValue)]
        public double? Area { get; set; }
    }
}
