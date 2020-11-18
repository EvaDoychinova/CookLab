namespace CookLab.Models.ViewModels.CookingVessels
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class CookingVesselRecipeViewModel : IMapFrom<CookingVessel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
