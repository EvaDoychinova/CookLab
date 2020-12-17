namespace CookLab.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Common.Models;
    using CookLab.Data.Models.Enums;

    using static CookLab.Common.ModelsValidations.CookingVesselValidations;

    public class CookingVessel : BaseDeletableModel<int>
    {
        public CookingVessel()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        [Required]
        [MaxLength(DatabaseNameMaxValue)]
        public string Name { get; set; }

        [Range(FormMinValue, FormMaxValue)]
        public PanForm Form { get; set; }

        [Range(FormsCountMinValue, FormsCountMaxValue)]
        public int? FormsCount { get; set; }

        [Range(DiameterMinValue, DiameterMaxValue)]
        public double? Diameter { get; set; }

        [Range(SideMinValue, SideMaxValue)]
        public double? SideA { get; set; }

        [Range(SideMinValue, SideMaxValue)]
        public double? SideB { get; set; }

        [Range(HeightMinValue, HeightMaxValue)]
        public double Height { get; set; }

        [Range(AreaMinValue, AreaMaxValue)]
        public double Area { get; set; }

        [Range(VolumeMinValue, VolumeMaxValue)]
        public double Volume { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
