namespace CookLab.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;

    internal class RecipesSeeder : ISeeder
    {
        private List<Recipe> recipesToAdd = new List<Recipe>
            {
                new Recipe
                {
                    Id = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                    Name = "Banana cake with chocolate",
                    CookingTime = TimeSpan.FromMinutes(30),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "efec153a-da79-40d0-a015-591238cdb244",
                            ImageUrl = "/assets/img/recipes/efec153a-da79-40d0-a015-591238cdb244.jpg",
                            RecipeId = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                            IngredientId = "6c327a20-d8b1-4769-a0e7-275b989cbbaa",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 400,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                            IngredientId = "d94dabc1-435e-4cf7-92a6-e0a27b23bcfb",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 40,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                            IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 150,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                            IngredientId = "8971987a-b01d-4f4b-bb9f-b62987c5f5ab",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 10,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                            IngredientId = "6cfd18bd-031f-4fb7-8b9d-35ecde7ad0fa",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 80,
                        },
                    },
                    Notes = "The baking of the bananas is in order for their flavour to be richer.",
                    Nutrition = new Nutrition
                    {
                        Calories = 1188.2,
                        Carbohydrates = 142.33,
                        Proteins = 37.04,
                        Fats = 53.065,
                        Fibres = 34.74,
                        RecipeId = "077abfb4-8b82-4ef8-b997-42f6009ec9b6",
                    },
                    Portions = 5,
                    Preparation = @"Bake the bananas with their peels in the oven for 15 minutes at 250°C.
After taking them out of the oven smash the bananas and let cool for about 5 minutes.
Add the eggs and stir together.
Add the flour and the baking powder and mix well.
Finally add the chopped chocolate.
Pour everything in a cakepan and bake for 30 minutes in preheated oven at 180°C.",
                },
                new Recipe
                {
                    Id = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                    Name = "Chocolate lava cake",
                    CookingTime = TimeSpan.FromMinutes(13),
                    PreparationTime = TimeSpan.FromMinutes(20),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                    },
                    Portions = 8,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
                new Recipe
                {
                    Id = "",
                    Name = "",
                    CookingTime = TimeSpan.FromMinutes(0),
                    PreparationTime = TimeSpan.FromMinutes(0),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 0,
                            RecipeId = "",
                        },
                    },
                    CookingVesselId = 1,
                    CreatorId = "",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "",
                            ImageUrl = "/assets/img/recipes/.jpg",
                            RecipeId = "",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "",
                            IngredientId = "",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 0,
                        },
                    },
                    Notes = "",
                    Nutrition = new Nutrition
                    {
                        Calories = 0,
                        Carbohydrates = 0,
                        Proteins = 0,
                        Fats = 0,
                        Fibres = 0,
                        RecipeId = "",
                    },
                    Portions = 0,
                    Preparation = @"",
                },
            };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Recipes.Any(x => x.IsDeleted == false))
            {
                return;
            }

            foreach (var recipe in this.recipesToAdd)
            {
                await dbContext.Recipes.AddAsync(recipe);
            }
        }
    }
}
