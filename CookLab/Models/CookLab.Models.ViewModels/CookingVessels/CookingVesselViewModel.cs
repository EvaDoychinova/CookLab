namespace CookLab.Models.ViewModels.CookingVessels
{
    using System.Globalization;

    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;
    using CookLab.Services.Mapping;

    public class CookingVesselViewModel : IMapFrom<CookingVessel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PanForm Form { get; set; }

        public int? FormsCount { get; set; }

        public double? Diameter { get; set; }

        public string DiameterToString => this.Diameter?.ToString("F2", CultureInfo.InvariantCulture);

        public double? SideA { get; set; }

        public string SideAToString => this.SideA?.ToString("F2", CultureInfo.InvariantCulture);

        public double? SideB { get; set; }

        public string SideBToString => this.SideB?.ToString("F2", CultureInfo.InvariantCulture);

        public double Height { get; set; }

        public string HeightToString => this.Height.ToString("F2", CultureInfo.InvariantCulture);

        public double Area { get; set; }

        public string AreaToString => this.Area.ToString("F2", CultureInfo.InvariantCulture);

        public double Volume { get; set; }

        public string VolumeToString => this.Volume.ToString("F2", CultureInfo.InvariantCulture);
    }
}
