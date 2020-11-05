namespace CookLab.Data.Models
{
    using System.Collections.Generic;

    using CookLab.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Recipes = new HashSet<CategoryRecipe>();
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<CategoryRecipe> Recipes { get; set; }
    }
}
