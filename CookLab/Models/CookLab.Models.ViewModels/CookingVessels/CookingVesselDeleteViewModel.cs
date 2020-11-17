namespace CookLab.Models.ViewModels.CookingVessels
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class CookingVesselDeleteViewModel : IMapFrom<CookingVessel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Area { get; set; }

        public double Volume { get; set; }
    }
}
