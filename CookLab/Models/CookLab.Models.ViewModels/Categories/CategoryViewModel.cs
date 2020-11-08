namespace CookLab.Models.ViewModels.Categories
{
    using CookLab.Data.Models;
    using CookLab.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
