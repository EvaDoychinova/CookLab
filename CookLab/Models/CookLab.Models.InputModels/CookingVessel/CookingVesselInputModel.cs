namespace CookLab.Models.InputModels.CookingVessel
{
    using System.ComponentModel.DataAnnotations;

    using CookLab.Data.Models.Enums;
    using CookLab.Web.Infrastructure.Attributes;

    using static CookLab.Common.DisplayNames.CookingVesselDisplayName;
    using static CookLab.Common.ErrorMessages;
    using static CookLab.Common.ModelsValidations.CookingVesselValidations;

    public class CookingVesselInputModel
    {
        [StringLength(NameMaxValue, MinimumLength = NameMinValue, ErrorMessage =StringLengthError)]
        [RequiredForm(PanForm.Custom, "Form")]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredSelectFiledError)]
        [Display(Name = FormDisplayName)]
        [Range(FormMinValue, FormMaxValue, ErrorMessage = InvalidEnumRangeError)]
        public PanForm Form { get; set; }

        [RequiredForm(PanForm.Circle, "Form")]
        [Range(DiameterMinValue, DiameterMaxValue)]
        public double? Diameter { get; set; }

        [RequiredForm(PanForm.Square, "Form")]
        [RequiredForm(PanForm.Rectangular, "Form")]
        [Range(SideMinValue, SideMaxValue)]
        public double? SideA { get; set; }

        [RequiredForm(PanForm.Rectangular, "Form")]
        [Range(SideMinValue, SideMaxValue)]
        public double? SideB { get; set; }

        [Required]
        [Range(HeightMinValue, HeightMaxValue)]
        public double Height { get; set; }

        [RequiredForm(PanForm.Custom, "Form")]
        [Range(VolumeMinValue, VolumeMaxValue)]
        public double? Area { get; set; }
    }
}
