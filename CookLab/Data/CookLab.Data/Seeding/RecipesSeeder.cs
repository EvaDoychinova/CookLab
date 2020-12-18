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
                        new CategoryRecipe
                        {
                            CategoryId = 8,
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
                            WeightInGrams = 180,
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
                        Calories = 1231.1,
                        Carbohydrates = 142.546,
                        Proteins = 40.808,
                        Fats = 55.918,
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
                            CategoryId = 1,
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 8,
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                        },
                    },
                    CookingVesselId = 32,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "0d338ebb-1763-4749-b663-c32a034267bf",
                            ImageUrl = "/assets/img/recipes/0d338ebb-1763-4749-b663-c32a034267bf.jpg",
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 240,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "5b9641d9-be43-4e16-b784-4b41a7cf6c9d",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 200,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "3f1b1bcf-f862-4d71-95ed-05c375a22fd3",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 200,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "d0751674-6a18-4e5c-a8cb-dfd1360019d5",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 40,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "688626bd-f41b-446d-ac21-03d6f67c5a06",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 90,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                            IngredientId = "58c37672-479a-4708-b1a0-9d006e758479",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                    },
                    Notes = @"You can use cocoa powder instead of flour to cover the forms.
In the process of baking it is important to watch the cakes so as not to overbake them. They are ready when the center is still a little liquid but they are firm on the sides.",
                    Nutrition = new Nutrition
                    {
                        Calories = 3448.4,
                        Carbohydrates = 215.448,
                        Proteins = 262.504,
                        Fats = 46.1455,
                        Fibres = 14.96,
                        RecipeId = "16c69763-bf82-4a49-9bdd-e0f4bf7c922d",
                    },
                    Portions = 8,
                    Preparation = @"Melt the chocolate, butter and sugar in a double boiler.
Leave them to cool a little.
Lightly beat the eggs and add them to the chocolate mixture.
Add the butter and the vanilla and stir together.
Grease the forms with a butter and cover them with flour.
Pour the chocolate mixture in the forms.
Leave in the freezer for at least 1 hour.
Bake right before eating in preheated oven at 220°C for between 10 and 13 minutes (depending on your oven).
After baking leave them for a minute to cool and turn them over in a plate prefferably with a ball of ice cream.",
                },
                new Recipe
                {
                    Id = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                    Name = "Brownie with raspberries",
                    CookingTime = TimeSpan.FromMinutes(25),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 8,
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                        },
                    },
                    CookingVesselId = 2,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "af5e635a-b253-4f6c-bf24-1d37556da317",
                            ImageUrl = "/assets/img/recipes/af5e635a-b253-4f6c-bf24-1d37556da317.jpg",
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                        },
                        new RecipeImage
                        {
                            Id = "1e563cad-35fd-4872-ac75-42c0422638a5",
                            ImageUrl = "/assets/img/recipes/1e563cad-35fd-4872-ac75-42c0422638a5.jpg",
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 180,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "82e6cbe2-4156-4c87-9919-35e9d401634d",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 40,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "859b0910-6e52-4922-b564-fc118d1aa93a",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 35,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "6a623090-9609-4c44-ba64-5052c4b687ac",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 60,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "f469c9a1-d72f-4489-8975-3ecc380174f4",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 55,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "58c37672-479a-4708-b1a0-9d006e758479",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "5b9641d9-be43-4e16-b784-4b41a7cf6c9d",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 150,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "fb109688-6e1c-4520-82f6-f0f789ce4e12",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 220,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "773dae3d-fe6a-421d-b47c-8a55242d574c",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 2,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                            IngredientId = "46003502-4c76-475d-8f4c-b281a2261c1d",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                    },
                    Notes = "If you don't have almond flour you can replace it with ground almonds but increase the quantity a little.",
                    Nutrition = new Nutrition
                    {
                        Calories = 2231.5,
                        Carbohydrates = 163.176,
                        Proteins = 56.1595,
                        Fats = 146.198,
                        Fibres = 43.3,
                        RecipeId = "46f6e21a-d7b3-4459-9357-a8a9387c5a67",
                    },
                    Portions = 8,
                    Preparation = @"Preheat the oven at 180°C.
Cover the cake pan with paper.
Beat the eggs and after that add the coconut butter, coconut sugar and the vanilla and mix together.
In a different bowl mix the dry ingredients - almond flour, cocoa powder, baking soda and salt.
Pour the dry ingredients in the egg mixture and stir together.
Add the chopped chocolate and the 3/4 of the raspberries and mix everything.
Pour the mixture in the cake pan, level it and spread the rest of the raspberries on top.
Bake in the preheated oven at 180°C for about 20-25 minutes.
Leave to cool completely before serving.",
                },
                new Recipe
                {
                    Id = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                    Name = "Cake with apricots",
                    CookingTime = TimeSpan.FromMinutes(25),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 8,
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                        },
                    },
                    CookingVesselId = 11,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "6a54f003-4d91-41ff-b2f9-c19ca580cf5c",
                            ImageUrl = "/assets/img/recipes/6a54f003-4d91-41ff-b2f9-c19ca580cf5c.jpg",
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                            IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 120,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                            IngredientId = "82e6cbe2-4156-4c87-9919-35e9d401634d",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 100,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                            IngredientId = "6a623090-9609-4c44-ba64-5052c4b687ac",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 90,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                            IngredientId = "d3b5e690-dfd5-4bc8-95ac-ba8de3c4e768",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 120,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                            IngredientId = "46003502-4c76-475d-8f4c-b281a2261c1d",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 3,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                            IngredientId = "36fd1c5f-a495-48fb-bff6-0227d5ef8058",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 1,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                            IngredientId = "be26588f-71dd-4afe-a3ac-1ff5c0dfa625",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 1,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                            IngredientId = "1a15807b-060d-4311-a494-cbc06fa5bcb0",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 1,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                            IngredientId = "5b8c7c99-fec5-447e-9fb1-d8defb734ce1",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 220,
                        },
                    },
                    Notes = @"You can replace the almond flour with ground almonds but you need to increase the amount a little.
If the dates a dry rinse them in hot water for at least 30 minutes.",
                    Nutrition = new Nutrition
                    {
                        Calories = 1813.53,
                        Carbohydrates = 144.6719,
                        Proteins = 61.3379,
                        Fats = 114.3864,
                        Fibres = 34.947,
                        RecipeId = "72791c64-ee4b-4462-99b6-6e9469f09f72",
                    },
                    Portions = 8,
                    Preparation = @"Preheat the oven at 170°C.
Cover the cake pan with baking paper.
Mix the eggs and the dates in a blender and blend until they become creamy.
Add the coconut butter and mix slightly.
In another bowl mix the dry inredients - almond flour, baking soda and the spices.
Add the dry ingredients to the egg mixture and mix everything.
Add the vinegar to put out the baking soda.
Pour the mixture in the cake pan.
Cut the apricots in slices and order then over the leveled cake mixture.
Bake for about 20-25 minutes. Check if ready with a wooden stick.
Leave to cool well before serving.",
                },
                new Recipe
                {
                    Id = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                    Name = "Garash cake",
                    CookingTime = TimeSpan.FromMinutes(60),
                    PreparationTime = TimeSpan.FromMinutes(90),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 8,
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                        },
                    },
                    CookingVesselId = 3,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "6f25b966-2348-43f9-adb5-1c09a30a463c",
                            ImageUrl = "/assets/img/recipes/6f25b966-2348-43f9-adb5-1c09a30a463c.jpg",
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                            IngredientId = "1f1ee6d8-55d3-491a-b996-2df85d2c0693",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 325,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                            IngredientId = "d6dcff38-0def-4756-a035-7389434c0971",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 300,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                            IngredientId = "ad98623b-b2c1-450a-b3ff-2326f4fc2a30",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 100,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                            IngredientId = "ad98623b-b2c1-450a-b3ff-2326f4fc2a30",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 100,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                            IngredientId = "78ff3e85-34cd-4c4c-9fce-053fe30b6b1b",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 200,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                            IngredientId = "3f1b1bcf-f862-4d71-95ed-05c375a22fd3",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 200,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                            IngredientId = "45e2a888-2fb6-4015-a256-2d418f2af8bb",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 50,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                            IngredientId = "859b0910-6e52-4922-b564-fc118d1aa93a",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 100,
                        },
                    },
                    Nutrition = new Nutrition
                    {
                        Calories = 5551,
                        Carbohydrates = 267.0175,
                        Proteins = 134.115,
                        Fats = 445.9425,
                        Fibres = 50.1,
                        RecipeId = "6eba49d8-0446-4da3-9dca-ac5d9575a17a",
                    },
                    Portions = 12,
                    Preparation = @"Preheat the oven at 180°C.
Cover the cake pan with baking paper and grease it on top.
Whip the egg whites with the sugar for the cake layers until almost stiff and add the coarsly ground walnuts.
Divide in 4 parts for 4 different cake layers.
Bake each of the layer for 12-15 minutes until a little red on the sides.
Let cool over a grate.
Cut the butter in cubes and melt on medium heat. 
Add the sifted cocoa powder so an not to have any lumps.
Whip the yolks and the sugar for the cream until they turn white and thick.
While whipping with the mixer add the cocoa mixture in thin stream.
Add the sour cream in the end and mix by hand.
Leave in the fridge for a couple of hours.
Start assembling the cake by spreading cream over every cake layer and leave enough to v=cover the whole cake in the end.
Decorate with ground or sliced almonds or shreaded coconut.
Leave in the fridge at least for a couple of hours.",
                },
                new Recipe
                {
                    Id = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                    Name = "Chocolate truffles",
                    CookingTime = TimeSpan.FromMinutes(15),
                    PreparationTime = TimeSpan.FromMinutes(20),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 17,
                            RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                        },
                    },
                    CookingVesselId = 25,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "ba389050-9082-48ec-9648-ddd672523876",
                            ImageUrl = "/assets/img/recipes/ba389050-9082-48ec-9648-ddd672523876.jpg",
                            RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                            IngredientId = "6cfd18bd-031f-4fb7-8b9d-35ecde7ad0fa",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 220,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                            IngredientId = "5522542b-7cc4-46a6-953f-63840e215b3c",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 40,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                            IngredientId = "7bfc39f0-e193-422e-8ccb-aa3eb1ce5090",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 90,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                            IngredientId = "4b4176c4-0469-490f-a182-1d5824dfe2f4",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 25,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                            IngredientId = "773dae3d-fe6a-421d-b47c-8a55242d574c",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 2,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                            IngredientId = "859b0910-6e52-4922-b564-fc118d1aa93a",
                            PartOfRecipe = IngredientPartOfRecipe.Topping,
                            WeightInGrams = 25,
                        },
                    },
                    Nutrition = new Nutrition
                    {
                        Calories = 2144.8,
                        Carbohydrates = 127.03,
                        Proteins = 24.055,
                        Fats = 170.32,
                        Fibres = 31.53,
                        RecipeId = "f0d9f387-782f-4907-b5c3-5f4c66690244",
                    },
                    Portions = 40,
                    Preparation = @"Melt the Chocolate and the honey in double boiler.
Add the butter and whisk until mixed together.
Finally add the cold cream and stir until everything is well mixed.
Put the mixture in the spray and form the truffles.
Cover with sifted cocoa powder and let cool completely.",
                },
                new Recipe
                {
                    Id = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                    Name = "Red lentils cream soup",
                    CookingTime = TimeSpan.FromMinutes(30),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 5,
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 9,
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 10,
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                        },
                    },
                    CookingVesselId = 5,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "b2d40ebb-f093-4762-82d6-cd7fbf5d246c",
                            ImageUrl = "/assets/img/recipes/b2d40ebb-f093-4762-82d6-cd7fbf5d246c.jpg",
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "ff26afc9-b85c-4c7f-91b6-195e9e6c3b81",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 160,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "15375c7e-603f-4a95-bcf8-2486204045e8",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 75,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "caf881c8-449e-4fff-a3f6-53558dd78a57",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 75,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "77bf9d95-e8cb-4124-b149-1f6a64c725c4",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 20,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "0675495b-e66b-4543-998b-300a12dcbed2",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 1000,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "c5c813cc-725d-4297-8669-c0f5134a54f4",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "fac7fc02-ee17-4200-a557-e873e69f3015",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "18cba7e5-9280-47a7-b35b-c16d53131274",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "93076c8f-d63d-4572-b017-1ee0090ae3e2",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 3,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                            IngredientId = "773dae3d-fe6a-421d-b47c-8a55242d574c",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                    },
                    Notes = "If the soup gets too thick add some more water.",
                    Nutrition = new Nutrition
                    {
                        Calories = 858.34,
                        Carbohydrates = 125.725,
                        Proteins = 42.0965,
                        Fats = 24.279,
                        Fibres = 25.764,
                        RecipeId = "9cfb62cc-e24c-4a79-acc9-6261dd6cd205",
                    },
                    Portions = 4,
                    Preparation = @"Chop the onion and the carrot in little cubes.
Heat the oil and add the vegetables.
Stir and stew for about 3-4 minutes.
Add the washed red lentils and the water.
After the soup has boiled add all the spices.
Boil for about 30 minutes or until the lentils is cooked.
After removing from the heat take out the bay leaf and blend.
Serve it garnished with some fresh parsley or sesame seeds.",
                },
                new Recipe
                {
                    Id = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                    Name = "Peanut butter chocolate bars",
                    CookingTime = TimeSpan.FromMinutes(10),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 3,
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 9,
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 10,
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                        },
                    },
                    CookingVesselId = 34,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "5f7cdfc3-1cc5-4eb4-9840-c66abcaa16be",
                            ImageUrl = "/assets/img/recipes/5f7cdfc3-1cc5-4eb4-9840-c66abcaa16be.jpg",
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                            IngredientId = "be14c967-9dbb-4f0e-844f-8cfdaf1a387e",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 60,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                            IngredientId = "0f117d6c-bbdc-4b8b-b332-433faf79d895",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 50,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                            IngredientId = "a7532c0b-cf7d-4461-82e3-5860ce3bd8a8",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 55,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                            IngredientId = "d4bacd75-b762-441a-a713-8460fd14570a",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 95,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                            IngredientId = "6cfd18bd-031f-4fb7-8b9d-35ecde7ad0fa",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 100,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                            IngredientId = "6a623090-9609-4c44-ba64-5052c4b687ac",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 55,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                            IngredientId = "d4bacd75-b762-441a-a713-8460fd14570a",
                            PartOfRecipe = IngredientPartOfRecipe.Topping,
                            WeightInGrams = 20,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                            IngredientId = "6a623090-9609-4c44-ba64-5052c4b687ac",
                            PartOfRecipe = IngredientPartOfRecipe.Topping,
                            WeightInGrams = 5,
                        },
                    },
                    Notes = "Take out of the fridge for at least 15 minutes before you cut it!",
                    Nutrition = new Nutrition
                    {
                        Calories = 2522.7,
                        Carbohydrates = 144.155,
                        Proteins = 61.035,
                        Fats = 187.875,
                        Fibres = 30.525,
                        RecipeId = "e326d5e4-9504-4a28-b1c0-9f40c5617888",
                    },
                    Portions = 8,
                    Preparation = @"Blend the oats and the almonds until finely ground.
Add the maple syrup and the peanut butter and mix everything well.
Cover the cooking vessel with baking paper and press and level well the mixture to its bottom.
Melt the chocolate with the coconut butter in double boiler and pour the chocolate mixture over base.
Melt the panut butter and coconut butter for decoration and pour little amounts that you stir into the chocolate layer.
Put it in the fridge for about an hour until firm.",
                },
                new Recipe
                {
                    Id = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                    Name = "Raw cashew cheesecake with coffee",
                    CookingTime = TimeSpan.FromMinutes(30),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 9,
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 10,
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                        },
                    },
                    CookingVesselId = 4,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "5e9eebef-56c7-4d2a-8a64-055bb0d0e9c6",
                            ImageUrl = "/assets/img/recipes/5e9eebef-56c7-4d2a-8a64-055bb0d0e9c6.jpg",
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "0f117d6c-bbdc-4b8b-b332-433faf79d895",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 100,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "7a08073b-0b39-4b7b-a2d9-732f4a0cfa65",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 50,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "d3b5e690-dfd5-4bc8-95ac-ba8de3c4e768",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 180,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "ed765ac1-e16c-4000-b981-2e95a3ccc085",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 220,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "d3bb43dc-e653-405c-b2e5-9f670dd37f97",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 200,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "6a623090-9609-4c44-ba64-5052c4b687ac",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 130,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "f9e2c68e-a5a0-4334-b4f8-fc2db204b5d7",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 50,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "4b4176c4-0469-490f-a182-1d5824dfe2f4",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 100,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "773dae3d-fe6a-421d-b47c-8a55242d574c",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 2,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "58c37672-479a-4708-b1a0-9d006e758479",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 5,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                            IngredientId = "d0049ee3-67dd-4754-8133-3a463559e180",
                            PartOfRecipe = IngredientPartOfRecipe.Cream2,
                            WeightInGrams = 25,
                        },
                    },
                    Notes = @"You can add some additional flavour in the first layer of the cream - for example linden.
You can add also some kind of liquor in the coffee layer if you want.",
                    Nutrition = new Nutrition
                    {
                        Calories = 4679.25,
                        Carbohydrates = 370.114,
                        Proteins = 77.2315,
                        Fats = 357.332,
                        Fibres = 45.91,
                        RecipeId = "cb78d198-129f-4f0a-abd3-87c770e07e91",
                    },
                    Portions = 12,
                    Preparation = @"Rinse the cashew for at least 6 hours.
Blend the almonds, add the shreaded coconut and the dates for the base and blend well.
Press and level well the base in the cake pan.
Drain the cashew and put it in a blender.
Add the lemon juice, coconut milk, honey, salt and vanilla and blend together for at least 3-4 minutes.
Melt the coconut butter in double boiler and add it to the cream mixture.
Stir a little to mix and divide the cream in 2 parts.
Pour one half over the base and put in the freezer to get firm.
Add the coffee to the second half and pour over the first one after it has cooled.
Put in the fridge for a couple of hours before serving.",
                },
                new Recipe
                {
                    Id = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                    Name = "Brownie with walnut paste",
                    CookingTime = TimeSpan.FromMinutes(15),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 8,
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                        },
                    },
                    CookingVesselId = 2,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "8db15848-0f05-4ff0-8acc-d7aa57386735",
                            ImageUrl = "/assets/img/recipes/8db15848-0f05-4ff0-8acc-d7aa57386735.jpg",
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                        },
                        new RecipeImage
                        {
                            Id = "b728ea48-8c25-4cd1-b773-fb57ff34f05a",
                            ImageUrl = "/assets/img/recipes/b728ea48-8c25-4cd1-b773-fb57ff34f05a.jpg",
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                            IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 120,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                            IngredientId = "fbe5df7c-219d-4ccd-9fd7-c235c8d0a0ac",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 150,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                            IngredientId = "f469c9a1-d72f-4489-8975-3ecc380174f4",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 100,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                            IngredientId = "5b9641d9-be43-4e16-b784-4b41a7cf6c9d",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 80,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                            IngredientId = "5522542b-7cc4-46a6-953f-63840e215b3c",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 20,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                            IngredientId = "773dae3d-fe6a-421d-b47c-8a55242d574c",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 2,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                            IngredientId = "8971987a-b01d-4f4b-bb9f-b62987c5f5ab",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                            IngredientId = "58c37672-479a-4708-b1a0-9d006e758479",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                    },
                    Notes = @"You can replace the baking powder with baking soda.",
                    Nutrition = new Nutrition
                    {
                        Calories = 2156.25,
                        Carbohydrates = 153.369,
                        Proteins = 42.6535,
                        Fats = 158.312,
                        Fibres = 20.61,
                        RecipeId = "737c4ef5-b78a-4a0e-863a-acd92b13e5b5",
                    },
                    Portions = 8,
                    Preparation = @"Preheat the oven at 160°C.
Cover the can pan with baking paper.
Mix the eggs with the walnut paste.
Melt the chocolate, the coconut butter and the sugar.You can leave the bigger pieces of unmelted chocolate if you want.
Mix all the ingredients and add the vanilla, salt and baking powder.
Pour in the cake pan and sprinkle a little sea salt crystals on top.
Bake for 15 minutes.
Take out of the oven for at least 10 minutes.
Serve with walnuts and honey or ice cream.",
                },
                new Recipe
                {
                    Id = "d45b7591-3d75-4793-9768-05f991a8134a",
                    Name = "Chocolate and walnut cake",
                    CookingTime = TimeSpan.FromMinutes(15),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 8,
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                        },
                    },
                    CookingVesselId = 35,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "7755de47-71b7-47d2-9200-f36f71858850",
                            ImageUrl = "/assets/img/recipes/7755de47-71b7-47d2-9200-f36f71858850.jpg",
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                        },
                        new RecipeImage
                        {
                            Id = "e515d274-e9c9-4bcb-bd12-698d45c0629a",
                            ImageUrl = "/assets/img/recipes/e515d274-e9c9-4bcb-bd12-698d45c0629a.jpg",
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                            IngredientId = "5b9641d9-be43-4e16-b784-4b41a7cf6c9d",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 100,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                            IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 180,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                            IngredientId = "d6dcff38-0def-4756-a035-7389434c0971",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 70,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                            IngredientId = "d94dabc1-435e-4cf7-92a6-e0a27b23bcfb",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 40,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                            IngredientId = "8971987a-b01d-4f4b-bb9f-b62987c5f5ab",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                            IngredientId = "36fd1c5f-a495-48fb-bff6-0227d5ef8058",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 10,
                        },
                    },
                    Notes = "You can serve with sour cream and cinnamon or a little of your favourite nut paste.",
                    Nutrition = new Nutrition
                    {
                        Calories = 1426.55,
                        Carbohydrates = 76.737,
                        Proteins = 46.368,
                        Fats = 103.289,
                        Fibres = 32.61,
                        RecipeId = "d45b7591-3d75-4793-9768-05f991a8134a",
                    },
                    Portions = 6,
                    Preparation = @"Preheat the oven at 180°C.
Cover the cooking vessel with baking paper.
Whip the eggs with the mixer.
Add the baking powder, coconut flour and cinnamon and stir together.
Chop teh chocolate and the walnuts and add them to the mixture.
Pour in the cake pan and sprinkle a little chocolate and walnuts on top.
Bake for 15 minutes.
After taken out of the oven let cool completely before cutting into pieces.",
                },
                new Recipe
                {
                    Id = "3052e5e1-3608-471b-a0e1-735697e51877",
                    Name = "Chocolate chichpea brownie",
                    CookingTime = TimeSpan.FromMinutes(20),
                    PreparationTime = TimeSpan.FromMinutes(15),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 9,
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 10,
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                        },
                    },
                    CookingVesselId = 10,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "49aeee75-95ce-43b2-9aae-4faf9274a2b8",
                            ImageUrl = "/assets/img/recipes/49aeee75-95ce-43b2-9aae-4faf9274a2b8.jpg",
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                            IngredientId = "2fa8a3a5-86f2-4951-b1f5-1585bd7ff90e",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 250,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                            IngredientId = "6cfd18bd-031f-4fb7-8b9d-35ecde7ad0fa",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 10,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                            IngredientId = "d3b5e690-dfd5-4bc8-95ac-ba8de3c4e768",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 80,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                            IngredientId = "d6dcff38-0def-4756-a035-7389434c0971",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 50,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                            IngredientId = "6a623090-9609-4c44-ba64-5052c4b687ac",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 55,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                            IngredientId = "5db3ec64-291b-4ec2-89ec-efe035c7fa44",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 30,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                            IngredientId = "773dae3d-fe6a-421d-b47c-8a55242d574c",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 2,
                        },
                    },
                    Notes = "You can change the hazelnut paste with any other nut paste you want.",
                    Nutrition = new Nutrition
                    {
                        Calories = 1719.9,
                        Carbohydrates = 145.419,
                        Proteins = 37.06,
                        Fats = 116.297,
                        Fibres = 30.44,
                        RecipeId = "3052e5e1-3608-471b-a0e1-735697e51877",
                    },
                    Portions = 12,
                    Preparation = @"Preheat the oven at 170°C.
Cover the cake pan with baking paper.
Melt the chocolate in double boiler.
Blend all of the ingredients except for the walnuts.
Chop the walnuts, add them to the mixture and stir well.
Pour the mixture in the cake pan.
Bake for 20 minutes.
Let cool after taking it out of the oven.",
                },
                new Recipe
                {
                    Id = "14d8fa6b-987a-4155-9958-3d640bc21213",
                    Name = "Coconut cookies",
                    CookingTime = TimeSpan.FromMinutes(8),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 3,
                            RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 8,
                            RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                        },
                    },
                    CookingVesselId = 25,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "232d2e0a-45fb-452c-a18d-40fe22a85e82",
                            ImageUrl = "/assets/img/recipes/232d2e0a-45fb-452c-a18d-40fe22a85e82.jpg",
                            RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                            IngredientId = "7a08073b-0b39-4b7b-a2d9-732f4a0cfa65",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 200,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                            IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 120,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                            IngredientId = "3f1b1bcf-f862-4d71-95ed-05c375a22fd3",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 50,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                            IngredientId = "688626bd-f41b-446d-ac21-03d6f67c5a06",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 90,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                            IngredientId = "58c37672-479a-4708-b1a0-9d006e758479",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 10,
                        },
                    },
                    Nutrition = new Nutrition
                    {
                        Calories = 2273.7,
                        Carbohydrates = 114.804,
                        Proteins = 29.325,
                        Fats = 182.662,
                        Fibres = 28,
                        RecipeId = "14d8fa6b-987a-4155-9958-3d640bc21213",
                    },
                    Portions = 20,
                    Preparation = @"Let the butter in room temperature to soften.
Preheat the oven at 170°C.
Whisk the eggs, sugar and vanilla together with slow mixer ot wire stirrer.
Add the butter and stir well.
In a big bowl add the shreaded coconut and mix together.
Form little balls with hands or use teaspoon.
Bake for 7-8 minutes or until they start to get a little red.",
                },
                new Recipe
                {
                    Id = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                    Name = "Protein cheese salty cakes",
                    CookingTime = TimeSpan.FromMinutes(15),
                    PreparationTime = TimeSpan.FromMinutes(15),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 8,
                            RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 18,
                            RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                        },
                    },
                    CookingVesselId = 33,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "2320ae5c-0b04-450a-b3b2-ae5afc8cee71",
                            ImageUrl = "/assets/img/recipes/2320ae5c-0b04-450a-b3b2-ae5afc8cee71.jpg",
                            RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                        },
                        new RecipeImage
                        {
                            Id = "4d834c0e-e0d7-4338-b192-d574837d4f20",
                            ImageUrl = "/assets/img/recipes/4d834c0e-e0d7-4338-b192-d574837d4f20.jpg",
                            RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                            IngredientId = "0fb9eab7-271e-4f84-8bfe-ccfa5dfea76b",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 180,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                            IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 280,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                            IngredientId = "e1b122e2-ecac-4e0c-acf3-d099fa4be033",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 400,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                            IngredientId = "8971987a-b01d-4f4b-bb9f-b62987c5f5ab",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 7,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                            IngredientId = "20b579cf-009b-4b2c-a7f9-705ec572bcb5",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 2,
                        },
                    },
                    Notes = @"You can also add other spices depending on your taste.
You can also add olives or peppers.",
                    Nutrition = new Nutrition
                    {
                        Calories = 1233.61,
                        Carbohydrates = 20.255,
                        Proteins = 108.588,
                        Fats = 79.088,
                        Fibres = 0.014,
                        RecipeId = "8f9b2607-3f77-41f6-b8be-4fb2a910fd9f",
                    },
                    Portions = 4,
                    Preparation = @"Preheat the oven at 200°C.
Whisk the eggs, crumbled cheese, cottage cheese and the spices and mix everything together.
In the end add the baking powder and mix again.
Pour evenly into the forms.
Bake for about 15-20 minutes or until they start to get a little red on the top.",
                },
                new Recipe
                {
                    Id = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                    Name = "Healthy cocoa banana cake",
                    CookingTime = TimeSpan.FromMinutes(15),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 8,
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                        },
                    },
                    CookingVesselId = 19,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "41dfd695-1d5e-4779-b81e-ef4da4de1c5d",
                            ImageUrl = "/assets/img/recipes/41dfd695-1d5e-4779-b81e-ef4da4de1c5d.jpg",
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                        },
                        new RecipeImage
                        {
                            Id = "b11af1e3-1032-4b29-8a58-bd1055df16bb",
                            ImageUrl = "/assets/img/recipes/b11af1e3-1032-4b29-8a58-bd1055df16bb.jpg",
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                            IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 300,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                            IngredientId = "6c327a20-d8b1-4769-a0e7-275b989cbbaa",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 400,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                            IngredientId = "e1b122e2-ecac-4e0c-acf3-d099fa4be033",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 200,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                            IngredientId = "859b0910-6e52-4922-b564-fc118d1aa93a",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 50,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                            IngredientId = "8971987a-b01d-4f4b-bb9f-b62987c5f5ab",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                            IngredientId = "58c37672-479a-4708-b1a0-9d006e758479",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 20,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                            IngredientId = "36fd1c5f-a495-48fb-bff6-0227d5ef8058",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 10,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                            IngredientId = "be26588f-71dd-4afe-a3ac-1ff5c0dfa625",
                            PartOfRecipe = IngredientPartOfRecipe.All,
                            WeightInGrams = 5,
                        },
                    },
                    Notes = "You can por the mixture in muffin forms if you want but increase the baking time if you decide to do so.",
                    Nutrition = new Nutrition
                    {
                        Calories = 1234.8,
                        Carbohydrates = 118.609,
                        Proteins = 74.435,
                        Fats = 52.789,
                        Fibres = 31.76,
                        RecipeId = "26bcc896-4fab-4f5c-b54b-bd6bf2bdc1b4",
                    },
                    Portions = 4,
                    Preparation = @"Preheat the oven at 180°C.
Blend all the ingredients together.
Pour the mixture in the cake pan.
Bake about 25 minutes or until ready (check with wooden stick).",
                },
                new Recipe
                {
                    Id = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                    Name = "Raw 4-ingredient cake",
                    CookingTime = TimeSpan.FromMinutes(15),
                    PreparationTime = TimeSpan.FromMinutes(15),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 9,
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 10,
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                        },
                    },
                    CookingVesselId = 4,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "9966b686-6550-44a1-ba81-1d850d66004a",
                            ImageUrl = "/assets/img/recipes/9966b686-6550-44a1-ba81-1d850d66004a.jpg",
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                        },
                        new RecipeImage
                        {
                            Id = "b4f3471c-8fff-49ad-850f-dd6869c1a765",
                            ImageUrl = "/assets/img/recipes/b4f3471c-8fff-49ad-850f-dd6869c1a765.jpg",
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                            IngredientId = "d4bacd75-b762-441a-a713-8460fd14570a",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 350,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                            IngredientId = "6c327a20-d8b1-4769-a0e7-275b989cbbaa",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 200,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                            IngredientId = "d6dcff38-0def-4756-a035-7389434c0971",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 120,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                            IngredientId = "d3b5e690-dfd5-4bc8-95ac-ba8de3c4e768",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 120,
                        },
                    },
                    Notes = @"You can put the dates in hot water for a couple of minutes if they are not moisty enough or add a little while blending.
You can decorate the cake with strawberries and ground walnuts.",
                    Nutrition = new Nutrition
                    {
                        Calories = 3492.2,
                        Carbohydrates = 185.068,
                        Proteins = 128.396,
                        Fats = 250.88,
                        Fibres = 44.19,
                        RecipeId = "2ed21b9f-9bf5-4408-b16e-7cc0beb410dd",
                    },
                    Portions = 12,
                    Preparation = @"Blend the walnuts.
Blend the dates and mix with the walnuts.
Spread the base evenly in the cake form.
Blend the banana and the peanut butter for the cream.
Pour the cream over the base.
Put in the fridge for a couple of hours.",
                },
                new Recipe
                {
                    Id = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                    Name = "Raw coffee cake",
                    CookingTime = TimeSpan.FromMinutes(30),
                    PreparationTime = TimeSpan.FromMinutes(30),
                    Categories = new List<CategoryRecipe>
                    {
                        new CategoryRecipe
                        {
                            CategoryId = 1,
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 2,
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 9,
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                        },
                        new CategoryRecipe
                        {
                            CategoryId = 10,
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                        },
                    },
                    CookingVesselId = 3,
                    CreatorId = "7ec698b4-5f8d-4c54-b775-91e2b5d83215",
                    Images = new List<RecipeImage>
                    {
                        new RecipeImage
                        {
                            Id = "a1962d7c-bafb-49e5-8a91-cd025d803dda",
                            ImageUrl = "/assets/img/recipes/a1962d7c-bafb-49e5-8a91-cd025d803dda.jpg",
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                        },
                    },
                    Ingredients = new List<RecipeIngredient>
                    {
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "0f117d6c-bbdc-4b8b-b332-433faf79d895",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 250,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "859b0910-6e52-4922-b564-fc118d1aa93a",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 25,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "d3b5e690-dfd5-4bc8-95ac-ba8de3c4e768",
                            PartOfRecipe = IngredientPartOfRecipe.Base,
                            WeightInGrams = 120,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "354ce8e5-c26e-4c4e-b5b9-82f95fa8a785",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 375,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "4b4176c4-0469-490f-a182-1d5824dfe2f4",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 120,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "d0049ee3-67dd-4754-8133-3a463559e180",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 25,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "859b0910-6e52-4922-b564-fc118d1aa93a",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 40,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "cc259637-9bf4-4a67-9c9c-2f02876f92f1",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 100,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "58c37672-479a-4708-b1a0-9d006e758479",
                            PartOfRecipe = IngredientPartOfRecipe.Cream1,
                            WeightInGrams = 2,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "4b4176c4-0469-490f-a182-1d5824dfe2f4",
                            PartOfRecipe = IngredientPartOfRecipe.Topping,
                            WeightInGrams = 120,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "5522542b-7cc4-46a6-953f-63840e215b3c",
                            PartOfRecipe = IngredientPartOfRecipe.Topping,
                            WeightInGrams = 20,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "859b0910-6e52-4922-b564-fc118d1aa93a",
                            PartOfRecipe = IngredientPartOfRecipe.Topping,
                            WeightInGrams = 40,
                        },
                        new RecipeIngredient
                        {
                            RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                            IngredientId = "d0049ee3-67dd-4754-8133-3a463559e180",
                            PartOfRecipe = IngredientPartOfRecipe.Topping,
                            WeightInGrams = 20,
                        },
                    },
                    Nutrition = new Nutrition
                    {
                        Calories = 4473.47,
                        Carbohydrates = 436.3965,
                        Proteins = 104.2056,
                        Fats = 284.058,
                        Fibres = 107.655,
                        RecipeId = "7dd9569f-ee49-41d5-bf7a-00a3e64c693f",
                    },
                    Portions = 12,
                    Preparation = @"Blend all ingredients for the base and press them to the cake pan.
Blend all ingredients for the cream except for the hazelnuts.
Stir most of the hazelnuts in the cream and pour over the base.
Put in the freezer until firm.
Stir everything for the topping and pour over the cream.
Put in the fridge for a couple of hours.
Decorate with the remaining hazelnuts.",
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
