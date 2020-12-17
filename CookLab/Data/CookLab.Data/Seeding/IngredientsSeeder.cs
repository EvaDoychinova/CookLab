namespace CookLab.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Models;

    internal class IngredientsSeeder : ISeeder
    {
        private List<Ingredient> ingredientsToAdd = new List<Ingredient>
        {
            new Ingredient
            {
                Id = "0675495b-e66b-4543-998b-300a12dcbed2",
                Name = "Water",
                VolumeInMlPer100Grams = 100,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 0,
                    Carbohydrates = 0,
                    Proteins = 0,
                    Fats = 0,
                    Fibres = 0,
                    IngredientId = "0675495b-e66b-4543-998b-300a12dcbed2",
                },
            },
            new Ingredient
            {
                Id = "688626bd-f41b-446d-ac21-03d6f67c5a06",
                Name = "Sugar",
                VolumeInMlPer100Grams = 123.48,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 400,
                    Carbohydrates = 100,
                    Proteins = 0,
                    Fats = 0,
                    Fibres = 0,
                    IngredientId = "688626bd-f41b-446d-ac21-03d6f67c5a06",
                },
            },
            new Ingredient
            {
                Id = "ad98623b-b2c1-450a-b3ff-2326f4fc2a30",
                Name = "Sugar brown",
                VolumeInMlPer100Grams = 117.65,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 400,
                    Carbohydrates = 100,
                    Proteins = 0,
                    Fats = 0,
                    Fibres = 0,
                    IngredientId = "ad98623b-b2c1-450a-b3ff-2326f4fc2a30",
                },
            },
            new Ingredient
            {
                Id = "773dae3d-fe6a-421d-b47c-8a55242d574c",
                Name = "Salt",
                VolumeInMlPer100Grams = 98.04,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 0,
                    Carbohydrates = 0,
                    Proteins = 0,
                    Fats = 0,
                    Fibres = 0,
                    IngredientId = "773dae3d-fe6a-421d-b47c-8a55242d574c",
                },
            },
            new Ingredient
            {
                Id = "a4d3ea1e-71f5-45a6-9e61-427e6dc94df8",
                Name = "Powdered sugar",
                VolumeInMlPer100Grams = 181.82,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 400,
                    Carbohydrates = 100,
                    Proteins = 0,
                    Fats = 0,
                    Fibres = 0,
                    IngredientId = "a4d3ea1e-71f5-45a6-9e61-427e6dc94df8",
                },
            },
            new Ingredient
            {
                Id = "d0751674-6a18-4e5c-a8cb-dfd1360019d5",
                Name = "Flour white wheat",
                VolumeInMlPer100Grams = 238.1,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 361,
                    Carbohydrates = 72.5,
                    Proteins = 12,
                    Fats = 1.7,
                    Fibres = 2.4,
                    IngredientId = "d0751674-6a18-4e5c-a8cb-dfd1360019d5",
                },
            },
            new Ingredient
            {
                Id = "4b712e42-6fea-4038-97b2-bcdf742ffc90",
                Name = "Flour whole grain wheat",
                VolumeInMlPer100Grams = 181.82,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 361,
                    Carbohydrates = 72.5,
                    Proteins = 12,
                    Fats = 1.7,
                    Fibres = 2.4,
                    IngredientId = "4b712e42-6fea-4038-97b2-bcdf742ffc90",
                },
            },
            new Ingredient
            {
                Id = "0b2308c5-07c4-4fbf-8bfc-8612caddca69",
                Name = "Flour whole grain rye",
                VolumeInMlPer100Grams = 263.16,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 349,
                    Carbohydrates = 76,
                    Proteins = 10.34,
                    Fats = 1.3,
                    Fibres = 8,
                    IngredientId = "0b2308c5-07c4-4fbf-8bfc-8612caddca69",
                },
            },
            new Ingredient
            {
                Id = "68771e27-8aa7-4842-9428-028710bed863",
                Name = "Flour corn",
                VolumeInMlPer100Grams = 156.25,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 362,
                    Carbohydrates = 76.89,
                    Proteins = 8.12,
                    Fats = 3.59,
                    Fibres = 7.3,
                    IngredientId = "68771e27-8aa7-4842-9428-028710bed863",
                },
            },
            new Ingredient
            {
                Id = "f2fc0e1c-9b2d-4b49-846b-b7f06d97b044",
                Name = "Flour rice",
                VolumeInMlPer100Grams = 156.25,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 578,
                    Carbohydrates = 126.6,
                    Proteins = 9.4,
                    Fats = 2.2,
                    Fibres = 3.8,
                    IngredientId = "f2fc0e1c-9b2d-4b49-846b-b7f06d97b044",
                },
            },
            new Ingredient
            {
                Id = "a055948a-302c-4704-bff6-efc8b138e635",
                Name = "Milk",
                VolumeInMlPer100Grams = 97,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 61,
                    Carbohydrates = 4.8,
                    Proteins = 3.15,
                    Fats = 3.25,
                    Fibres = 0,
                    IngredientId = "a055948a-302c-4704-bff6-efc8b138e635",
                },
            },
            new Ingredient
            {
                Id = "259330ba-69df-4ec9-b9c0-c8ed5d543e0b",
                Name = "Yogurt",
                VolumeInMlPer100Grams = 97,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 61,
                    Carbohydrates = 4.66,
                    Proteins = 3.47,
                    Fats = 3.25,
                    Fibres = 0,
                    IngredientId = "259330ba-69df-4ec9-b9c0-c8ed5d543e0b",
                },
            },
            new Ingredient
            {
                Id = "d18a53be-2263-4c38-a5d8-93457f157e35",
                Name = "Condensed milk",
                VolumeInMlPer100Grams = 107.53,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 321,
                    Carbohydrates = 54.4,
                    Proteins = 7.9,
                    Fats = 8.7,
                    Fibres = 0,
                    IngredientId = "d18a53be-2263-4c38-a5d8-93457f157e35",
                },
            },
            new Ingredient
            {
                Id = "3f1b1bcf-f862-4d71-95ed-05c375a22fd3",
                Name = "Butter",
                VolumeInMlPer100Grams = 103.09,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 749,
                    Carbohydrates = 01,
                    Proteins = 0.5,
                    Fats = 82.5,
                    Fibres = 0,
                    IngredientId = "3f1b1bcf-f862-4d71-95ed-05c375a22fd3",
                },
            },
            new Ingredient
            {
                Id = "d3056e55-6bdf-4e0f-975e-0e931f53bb53",
                Name = "Lentils",
                VolumeInMlPer100Grams = 117.65,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 352,
                    Carbohydrates = 63.4,
                    Proteins = 24.6,
                    Fats = 1.1,
                    Fibres = 10.7,
                    IngredientId = "d3056e55-6bdf-4e0f-975e-0e931f53bb53",
                },
            },
            new Ingredient
            {
                Id = "1fddd70d-98f0-4b93-916a-dbcf6b987729",
                Name = "Beans",
                VolumeInMlPer100Grams = 117.65,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 333,
                    Carbohydrates = 60.27,
                    Proteins = 23.36,
                    Fats = 0.85,
                    Fibres = 15.2,
                    IngredientId = "1fddd70d-98f0-4b93-916a-dbcf6b987729",
                },
            },
            new Ingredient
            {
                Id = "99405805-4048-4ea5-9486-5fe1c6632dbc",
                Name = "Rice",
                VolumeInMlPer100Grams = 112.36,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 370,
                    Carbohydrates = 79,
                    Proteins = 7.13,
                    Fats = 0.7,
                    Fibres = 1.3,
                    IngredientId = "99405805-4048-4ea5-9486-5fe1c6632dbc",
                },
            },
            new Ingredient
            {
                Id = "42aad046-4f59-41bf-a7df-c1ba2398d8ae",
                Name = "Semolina",
                VolumeInMlPer100Grams = 135.14,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 360,
                    Carbohydrates = 72.83,
                    Proteins = 12.68,
                    Fats = 1.05,
                    Fibres = 3.9,
                    IngredientId = "42aad046-4f59-41bf-a7df-c1ba2398d8ae",
                },
            },
            new Ingredient
            {
                Id = "4b4176c4-0469-490f-a182-1d5824dfe2f4",
                Name = "Honey",
                VolumeInMlPer100Grams = 69.44,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 304,
                    Carbohydrates = 82.4,
                    Proteins = 0.3,
                    Fats = 0,
                    Fibres = 0.2,
                    IngredientId = "4b4176c4-0469-490f-a182-1d5824dfe2f4",
                },
            },
            new Ingredient
            {
                Id = "8971987a-b01d-4f4b-bb9f-b62987c5f5ab",
                Name = "Baking powder",
                VolumeInMlPer100Grams = 131.58,
                NutritionPer100Grams = new Nutrition
                {
                    Id = "8971987a-b01d-4f4b-bb9f-b62987c5f5ab",
                    Calories = 53,
                    Carbohydrates = 27.7,
                    Proteins = 0,
                    Fats = 0,
                    Fibres = 0.2,
                    IngredientId = "8971987a-b01d-4f4b-bb9f-b62987c5f5ab",
                },
            },
            new Ingredient
            {
                Id = "46003502-4c76-475d-8f4c-b281a2261c1d",
                Name = "Baking soda",
                VolumeInMlPer100Grams = 114.94,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 0,
                    Carbohydrates = 0,
                    Proteins = 0,
                    Fats = 0,
                    Fibres = 0,
                    IngredientId = "46003502-4c76-475d-8f4c-b281a2261c1d",
                },
            },
            new Ingredient
            {
                Id = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                Name = "Eggs",
                VolumeInMlPer100Grams = 103.09,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 143,
                    Carbohydrates = 0.72,
                    Proteins = 12.56,
                    Fats = 9.51,
                    Fibres = 0,
                    IngredientId = "62658af6-1f20-48c7-b4fb-4391cf924f61",
                },
            },
            new Ingredient
            {
                Id = "1f1ee6d8-55d3-491a-b996-2df85d2c0693",
                Name = "Egg whites",
                VolumeInMlPer100Grams = 107.53,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 52,
                    Carbohydrates = 0.73,
                    Proteins = 10.9,
                    Fats = 0.17,
                    Fibres = 0,
                    IngredientId = "1f1ee6d8-55d3-491a-b996-2df85d2c0693",
                },
            },
            new Ingredient
            {
                Id = "78ff3e85-34cd-4c4c-9fce-053fe30b6b1b",
                Name = "Egg yolks",
                VolumeInMlPer100Grams = 87.72,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 322,
                    Carbohydrates = 3.6,
                    Proteins = 15.9,
                    Fats = 26.5,
                    Fibres = 0,
                    IngredientId = "78ff3e85-34cd-4c4c-9fce-053fe30b6b1b",
                },
            },
            new Ingredient
            {
                Id = "6c327a20-d8b1-4769-a0e7-275b989cbbaa",
                Name = "Bananas",
                VolumeInMlPer100Grams = 78.86,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 89,
                    Carbohydrates = 22.84,
                    Proteins = 1.09,
                    Fats = 0.33,
                    Fibres = 2.6,
                    IngredientId = "6c327a20-d8b1-4769-a0e7-275b989cbbaa",
                },
            },
            new Ingredient
            {
                Id = "3c7e5cc7-38c9-4611-b6ca-a3fc67768b8f",
                Name = "Buckwheat",
                VolumeInMlPer100Grams = 138.89,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 359,
                    Carbohydrates = 68,
                    Proteins = 13,
                    Fats = 3,
                    Fibres = 0,
                    IngredientId = "3c7e5cc7-38c9-4611-b6ca-a3fc67768b8f",
                },
            },
            new Ingredient
            {
                Id = "36fd1c5f-a495-48fb-bff6-0227d5ef8058",
                Name = "Cinnamon",
                VolumeInMlPer100Grams = 196.08,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 247,
                    Carbohydrates = 80.59,
                    Proteins = 3.99,
                    Fats = 1.24,
                    Fibres = 53.1,
                    IngredientId = "36fd1c5f-a495-48fb-bff6-0227d5ef8058",
                },
            },
            new Ingredient
            {
                Id = "d0049ee3-67dd-4754-8133-3a463559e180",
                Name = "Coffee",
                VolumeInMlPer100Grams = 263.16,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 351,
                    Carbohydrates = 76,
                    Proteins = 11.6,
                    Fats = 0.2,
                    Fibres = 0,
                    IngredientId = "d0049ee3-67dd-4754-8133-3a463559e180",
                },
            },
            new Ingredient
            {
                Id = "abf15320-d742-4bed-937f-bf8bd535704d",
                Name = "Raisins",
                VolumeInMlPer100Grams = 156.25,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 300,
                    Carbohydrates = 78,
                    Proteins = 3,
                    Fats = 0.4,
                    Fibres = 4,
                    IngredientId = "abf15320-d742-4bed-937f-bf8bd535704d",
                },
            },
            new Ingredient
            {
                Id = "36697a62-6987-43e6-b188-84ecda1516e7",
                Name = "Starch",
                VolumeInMlPer100Grams = 131.58,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 381,
                    Carbohydrates = 91.27,
                    Proteins = 0.26,
                    Fats = 0.05,
                    Fibres = 0.9,
                    IngredientId = "36697a62-6987-43e6-b188-84ecda1516e7",
                },
            },
            new Ingredient
            {
                Id = "a808ae3e-f4f3-4e21-b334-a1368b12a40c",
                Name = "Gelatin",
                VolumeInMlPer100Grams = 107.53,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 335,
                    Carbohydrates = 0,
                    Proteins = 85.6,
                    Fats = 0.1,
                    Fibres = 0,
                    IngredientId = "a808ae3e-f4f3-4e21-b334-a1368b12a40c",
                },
            },
            new Ingredient
            {
                Id = "54c02e12-cffb-40c3-a75a-aa6ef8e87bf7",
                Name = "Ginger",
                VolumeInMlPer100Grams = 103.09,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 22,
                    Carbohydrates = 3.3,
                    Proteins = 3.1,
                    Fats = 0.3,
                    Fibres = 1,
                    IngredientId = "54c02e12-cffb-40c3-a75a-aa6ef8e87bf7",
                },
            },
            new Ingredient
            {
                Id = "3e0029c0-f775-4fb9-94a0-63add0ddbfd7",
                Name = "Ginger powder",
                VolumeInMlPer100Grams = 196.08,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 335,
                    Carbohydrates = 71.62,
                    Proteins = 8.98,
                    Fats = 4.24,
                    Fibres = 14.1,
                    IngredientId = "3e0029c0-f775-4fb9-94a0-63add0ddbfd7",
                },
            },
            new Ingredient
            {
                Id = "285efb1e-c12f-4fbd-9f94-41e42afe0da3",
                Name = "Molasses",
                VolumeInMlPer100Grams = 67.57,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 368,
                    Carbohydrates = 91,
                    Proteins = 0.7,
                    Fats = 0.1,
                    Fibres = 0,
                    IngredientId = "285efb1e-c12f-4fbd-9f94-41e42afe0da3",
                },
            },
            new Ingredient
            {
                Id = "90df6cb3-40e8-41c7-8179-f4bb190c81df",
                Name = "Milk powder",
                VolumeInMlPer100Grams = 138.89,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 479,
                    Carbohydrates = 38.7,
                    Proteins = 27,
                    Fats = 24,
                    Fibres = 0,
                    IngredientId = "90df6cb3-40e8-41c7-8179-f4bb190c81df",
                },
            },
            new Ingredient
            {
                Id = "77bf9d95-e8cb-4124-b149-1f6a64c725c4",
                Name = "Olive oil",
                VolumeInMlPer100Grams = 123.46,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 824,
                    Carbohydrates = 0,
                    Proteins = 0,
                    Fats = 91.60,
                    Fibres = 0,
                    IngredientId = "77bf9d95-e8cb-4124-b149-1f6a64c725c4",
                },
            },
            new Ingredient
            {
                Id = "d4bacd75-b762-441a-a713-8460fd14570a",
                Name = "Peanut butter",
                VolumeInMlPer100Grams = 131.58,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 626,
                    Carbohydrates = 9.4,
                    Proteins = 30,
                    Fats = 49,
                    Fibres = 6.1,
                    IngredientId = "d4bacd75-b762-441a-a713-8460fd14570a",
                },
            },
            new Ingredient
            {
                Id = "20b579cf-009b-4b2c-a7f9-705ec572bcb5",
                Name = "Black pepper",
                VolumeInMlPer100Grams = 175.44,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 255,
                    Carbohydrates = 65,
                    Proteins = 11,
                    Fats = 3,
                    Fibres = 0,
                    IngredientId = "20b579cf-009b-4b2c-a7f9-705ec572bcb5",
                },
            },
            new Ingredient
            {
                Id = "32f24def-1a02-472a-95cf-713c706e8c2e",
                Name = "Poppy seed",
                VolumeInMlPer100Grams = 175.44,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 525,
                    Carbohydrates = 28.13,
                    Proteins = 17.99,
                    Fats = 41.56,
                    Fibres = 19.5,
                    IngredientId = "32f24def-1a02-472a-95cf-713c706e8c2e",
                },
            },
            new Ingredient
            {
                Id = "be69a76a-b742-491c-ae59-8ba598a1ae49",
                Name = "Potatoes",
                VolumeInMlPer100Grams = 131.58,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 77,
                    Carbohydrates = 17.5,
                    Proteins = 2,
                    Fats = 0.1,
                    Fibres = 2.2,
                    IngredientId = "be69a76a-b742-491c-ae59-8ba598a1ae49",
                },
            },
            new Ingredient
            {
                Id = "0b792e9a-853d-418e-b793-4146d821b238",
                Name = "Sesame seed",
                VolumeInMlPer100Grams = 147.06,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 573,
                    Carbohydrates = 23.45,
                    Proteins = 17.73,
                    Fats = 49.67,
                    Fibres = 11.8,
                    IngredientId = "0b792e9a-853d-418e-b793-4146d821b238",
                },
            },
            new Ingredient
            {
                Id = "718ed143-8bdf-4f85-943f-3464bb88fc36",
                Name = "Rice wild",
                VolumeInMlPer100Grams = 163.93,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 357,
                    Carbohydrates = 74.9,
                    Proteins = 14.7,
                    Fats = 1.1,
                    Fibres = 6.2,
                    IngredientId = "718ed143-8bdf-4f85-943f-3464bb88fc36",
                },
            },
            new Ingredient
            {
                Id = "e8c96389-a485-46ef-889c-3245a8886728",
                Name = "Yeast",
                VolumeInMlPer100Grams = 160.35,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 325,
                    Carbohydrates = 41.2,
                    Proteins = 40.4,
                    Fats = 7.6,
                    Fibres = 26.9,
                    IngredientId = "e8c96389-a485-46ef-889c-3245a8886728",
                },
            },
            new Ingredient
            {
                Id = "7bfc39f0-e193-422e-8ccb-aa3eb1ce5090",
                Name = "Cooking cream",
                VolumeInMlPer100Grams = 100,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 337,
                    Carbohydrates = 3,
                    Proteins = 2.3,
                    Fats = 35,
                    Fibres = 0,
                    IngredientId = "7bfc39f0-e193-422e-8ccb-aa3eb1ce5090",
                },
            },
            new Ingredient
            {
                Id = "45e2a888-2fb6-4015-a256-2d418f2af8bb",
                Name = "Sour cream",
                VolumeInMlPer100Grams = 95.23,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 208,
                    Carbohydrates = 6.63,
                    Proteins = 2.4,
                    Fats = 19.52,
                    Fibres = 0,
                    IngredientId = "45e2a888-2fb6-4015-a256-2d418f2af8bb",
                },
            },
            new Ingredient
            {
                Id = "d94dabc1-435e-4cf7-92a6-e0a27b23bcfb",
                Name = "Coconut flour",
                VolumeInMlPer100Grams = 211.24,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 335,
                    Carbohydrates = 26,
                    Proteins = 19,
                    Fats = 8.5,
                    Fibres = 39,
                    IngredientId = "d94dabc1-435e-4cf7-92a6-e0a27b23bcfb",
                },
            },
            new Ingredient
            {
                Id = "d3bb43dc-e653-405c-b2e5-9f670dd37f97",
                Name = "Coconut milk",
                VolumeInMlPer100Grams = 103.73,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 230,
                    Carbohydrates = 5.5,
                    Proteins = 2.3,
                    Fats = 23.8,
                    Fibres = 2.2,
                    IngredientId = "d3bb43dc-e653-405c-b2e5-9f670dd37f97",
                },
            },
            new Ingredient
            {
                Id = "f9e2c68e-a5a0-4334-b4f8-fc2db204b5d7",
                Name = "Lemon juice",
                VolumeInMlPer100Grams = 102.88,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 22,
                    Carbohydrates = 56.9,
                    Proteins = 0.4,
                    Fats = 0.2,
                    Fibres = 0.3,
                    IngredientId = "f9e2c68e-a5a0-4334-b4f8-fc2db204b5d7",
                },
            },
            new Ingredient
            {
                Id = "5b55f227-54c2-4b2d-b11a-f27509a02df8",
                Name = "White Chocolate",
                VolumeInMlPer100Grams = 139.17,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 535,
                    Carbohydrates = 63,
                    Proteins = 4.6,
                    Fats = 29.5,
                    Fibres = 0,
                    IngredientId = "5b55f227-54c2-4b2d-b11a-f27509a02df8",
                },
            },
            new Ingredient
            {
                Id = "a13a97fa-907c-4854-a685-e1e62dfa308f",
                Name = "Milk Chocolate",
                VolumeInMlPer100Grams = 140.83,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 552,
                    Carbohydrates = 59.38,
                    Proteins = 4.69,
                    Fats = 32.81,
                    Fibres = 0,
                    IngredientId = "a13a97fa-907c-4854-a685-e1e62dfa308f",
                },
            },
            new Ingredient
            {
                Id = "5b9641d9-be43-4e16-b784-4b41a7cf6c9d",
                Name = "Dark Chocolate (45÷59%)",
                VolumeInMlPer100Grams = 138.36,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 550,
                    Carbohydrates = 46,
                    Proteins = 5.1,
                    Fats = 37,
                    Fibres = 7,
                    IngredientId = "5b9641d9-be43-4e16-b784-4b41a7cf6c9d",
                },
            },
            new Ingredient
            {
                Id = "1d37c8d6-a1f1-41df-bdc1-b62ec81d9e02",
                Name = "Dark Chocolate (60÷69%)",
                VolumeInMlPer100Grams = 137.55,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 579,
                    Carbohydrates = 52.4,
                    Proteins = 6.1,
                    Fats = 38.3,
                    Fibres = 8,
                    IngredientId = "1d37c8d6-a1f1-41df-bdc1-b62ec81d9e02",
                },
            },
            new Ingredient
            {
                Id = "6cfd18bd-031f-4fb7-8b9d-35ecde7ad0fa",
                Name = "Dark Chocolate (70÷85%)",
                VolumeInMlPer100Grams = 136.76,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 598,
                    Carbohydrates = 45.9,
                    Proteins = 7.8,
                    Fats = 42.6,
                    Fibres = 10.9,
                    IngredientId = "6cfd18bd-031f-4fb7-8b9d-35ecde7ad0fa",
                },
            },
            new Ingredient
            {
                Id = "859b0910-6e52-4922-b564-fc118d1aa93a",
                Name = "Cocoa powder",
                VolumeInMlPer100Grams = 200.50,
                NutritionPer100Grams = new Nutrition
                {
                    Id = "859b0910-6e52-4922-b564-fc118d1aa93a",
                    Calories = 374,
                    Carbohydrates = 11,
                    Proteins = 19,
                    Fats = 22,
                    Fibres = 30,
                    IngredientId = "859b0910-6e52-4922-b564-fc118d1aa93a",
                },
            },
            new Ingredient
            {
                Id = "5522542b-7cc4-46a6-953f-63840e215b3c",
                Name = "Cocoa butter",
                VolumeInMlPer100Grams = 108.53,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 891,
                    Carbohydrates = 0,
                    Proteins = 0,
                    Fats = 99,
                    Fibres = 0,
                    IngredientId = "5522542b-7cc4-46a6-953f-63840e215b3c",
                },
            },
            new Ingredient
            {
                Id = "d8cfa75c-7bae-457a-8653-2e13baf8d099",
                Name = "Carob flour",
                VolumeInMlPer100Grams = 229.70,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 222,
                    Carbohydrates = 88.9,
                    Proteins = 4.6,
                    Fats = 0.7,
                    Fibres = 39.8,
                    IngredientId = "d8cfa75c-7bae-457a-8653-2e13baf8d099",
                },
            },
            new Ingredient
            {
                Id = "d8a3d9ef-4534-4f5f-85f3-e6ab610f9e92",
                Name = "Chia seeds",
                VolumeInMlPer100Grams = 145.35,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 486,
                    Carbohydrates = 42.1,
                    Proteins = 16.5,
                    Fats = 30.7,
                    Fibres = 34.4,
                    IngredientId = "d8a3d9ef-4534-4f5f-85f3-e6ab610f9e92",
                },
            },
            new Ingredient
            {
                Id = "82e6cbe2-4156-4c87-9919-35e9d401634d",
                Name = "Almond flour",
                VolumeInMlPer100Grams = 246.45,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 380,
                    Carbohydrates = 28,
                    Proteins = 40,
                    Fats = 11,
                    Fibres = 20,
                    IngredientId = "82e6cbe2-4156-4c87-9919-35e9d401634d",
                },
            },
            new Ingredient
            {
                Id = "fbe5df7c-219d-4ccd-9fd7-c235c8d0a0ac",
                Name = "Walnut paste",
                VolumeInMlPer100Grams = 249.04,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 654,
                    Carbohydrates = 14,
                    Proteins = 15,
                    Fats = 65,
                    Fibres = 10,
                    IngredientId = "fbe5df7c-219d-4ccd-9fd7-c235c8d0a0ac",
                },
            },
            new Ingredient
            {
                Id = "5db3ec64-291b-4ec2-89ec-efe035c7fa44",
                Name = "Hazelnut paste",
                VolumeInMlPer100Grams = 204.92,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 675,
                    Carbohydrates = 18,
                    Proteins = 15,
                    Fats = 59,
                    Fibres = 2,
                    IngredientId = "5db3ec64-291b-4ec2-89ec-efe035c7fa44",
                },
            },
            new Ingredient
            {
                Id = "8ace4119-de0e-42be-aa13-427c3551b0da",
                Name = "Almond paste",
                VolumeInMlPer100Grams = 251.69,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 458,
                    Carbohydrates = 47.8,
                    Proteins = 9,
                    Fats = 27.7,
                    Fibres = 4.8,
                    IngredientId = "8ace4119-de0e-42be-aa13-427c3551b0da",
                },
            },
            new Ingredient
            {
                Id = "0f117d6c-bbdc-4b8b-b332-433faf79d895",
                Name = "Almonds",
                VolumeInMlPer100Grams = 165.45,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 579,
                    Carbohydrates = 21.55,
                    Proteins = 21.15,
                    Fats = 49.93,
                    Fibres = 12.5,
                    IngredientId = "0f117d6c-bbdc-4b8b-b332-433faf79d895",
                },
            },
            new Ingredient
            {
                Id = "ed765ac1-e16c-4000-b981-2e95a3ccc085",
                Name = "Cashew",
                VolumeInMlPer100Grams = 165.56,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 553,
                    Carbohydrates = 30.2,
                    Proteins = 18.2,
                    Fats = 43.9,
                    Fibres = 3.3,
                    IngredientId = "ed765ac1-e16c-4000-b981-2e95a3ccc085",
                },
            },
            new Ingredient
            {
                Id = "cc259637-9bf4-4a67-9c9c-2f02876f92f1",
                Name = "Hazelnuts",
                VolumeInMlPer100Grams = 171.23,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 628,
                    Carbohydrates = 16.7,
                    Proteins = 15,
                    Fats = 60.8,
                    Fibres = 9.7,
                    IngredientId = "cc259637-9bf4-4a67-9c9c-2f02876f92f1",
                },
            },
            new Ingredient
            {
                Id = "59f013a8-d43b-463a-853a-14f649cc1fc5",
                Name = "Peanuts",
                VolumeInMlPer100Grams = 162.05,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 570,
                    Carbohydrates = 15.8,
                    Proteins = 26.2,
                    Fats = 49.6,
                    Fibres = 9.5,
                    IngredientId = "59f013a8-d43b-463a-853a-14f649cc1fc5",
                },
            },
            new Ingredient
            {
                Id = "d6dcff38-0def-4756-a035-7389434c0971",
                Name = "Walnuts",
                VolumeInMlPer100Grams = 219.30,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 654,
                    Carbohydrates = 13.71,
                    Proteins = 15.23,
                    Fats = 65.21,
                    Fibres = 6.7,
                    IngredientId = "d6dcff38-0def-4756-a035-7389434c0971",
                },
            },
            new Ingredient
            {
                Id = "7a08073b-0b39-4b7b-a2d9-732f4a0cfa65",
                Name = "Coconut shredded",
                VolumeInMlPer100Grams = 254.40,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 681,
                    Carbohydrates = 11,
                    Proteins = 7,
                    Fats = 65,
                    Fibres = 14,
                    IngredientId = "7a08073b-0b39-4b7b-a2d9-732f4a0cfa65",
                },
            },
            new Ingredient
            {
                Id = "be14c967-9dbb-4f0e-844f-8cfdaf1a387e",
                Name = "Oats",
                VolumeInMlPer100Grams = 254.40,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 378,
                    Carbohydrates = 66,
                    Proteins = 13.5,
                    Fats = 6.7,
                    Fibres = 10.6,
                    IngredientId = "be14c967-9dbb-4f0e-844f-8cfdaf1a387e",
                },
            },
            new Ingredient
            {
                Id = "6a623090-9609-4c44-ba64-5052c4b687ac",
                Name = "Coconut butter",
                VolumeInMlPer100Grams = 109.46,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 900,
                    Carbohydrates = 0,
                    Proteins = 0.1,
                    Fats = 99.9,
                    Fibres = 0,
                    IngredientId = "6a623090-9609-4c44-ba64-5052c4b687ac",
                },
            },
            new Ingredient
            {
                Id = "878a6c1d-691f-4df0-8df0-241e1b785fb7",
                Name = "Grapeseed oil",
                VolumeInMlPer100Grams = 110.13,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 828,
                    Carbohydrates = 0,
                    Proteins = 0,
                    Fats = 92,
                    Fibres = 0,
                    IngredientId = "878a6c1d-691f-4df0-8df0-241e1b785fb7",
                },
            },
            new Ingredient
            {
                Id = "cc884630-05de-4e45-b001-bc5e022a3e19",
                Name = "Sesame oil",
                VolumeInMlPer100Grams = 108.46,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 884,
                    Carbohydrates = 0,
                    Proteins = 0,
                    Fats = 100,
                    Fibres = 0,
                    IngredientId = "cc884630-05de-4e45-b001-bc5e022a3e19",
                },
            },
            new Ingredient
            {
                Id = "af14591f-db4e-4031-b8fc-b78f59181460",
                Name = "Sesame paste",
                VolumeInMlPer100Grams = 92.42,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 644,
                    Carbohydrates = 7.4,
                    Proteins = 22.8,
                    Fats = 56,
                    Fibres = 5.5,
                    IngredientId = "af14591f-db4e-4031-b8fc-b78f59181460",
                },
            },
            new Ingredient
            {
                Id = "e1b122e2-ecac-4e0c-acf3-d099fa4be033",
                Name = "Cottage cheese",
                VolumeInMlPer100Grams = 105.15,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 99,
                    Carbohydrates = 2.4,
                    Proteins = 11.1,
                    Fats = 5,
                    Fibres = 0,
                    IngredientId = "e1b122e2-ecac-4e0c-acf3-d099fa4be033",
                },
            },
            new Ingredient
            {
                Id = "58c37672-479a-4708-b1a0-9d006e758479",
                Name = "Vanilla extract(powder)",
                VolumeInMlPer100Grams = 113.74,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 56,
                    Carbohydrates = 14.4,
                    Proteins = 0.03,
                    Fats = 0,
                    Fibres = 0,
                    IngredientId = "58c37672-479a-4708-b1a0-9d006e758479",
                },
            },
            new Ingredient
            {
                Id = "a7532c0b-cf7d-4461-82e3-5860ce3bd8a8",
                Name = "Maple syrup",
                VolumeInMlPer100Grams = 75.11,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 270,
                    Carbohydrates = 67.4,
                    Proteins = 0,
                    Fats = 0,
                    Fibres = 0,
                    IngredientId = "a7532c0b-cf7d-4461-82e3-5860ce3bd8a8",
                },
            },
            new Ingredient
            {
                Id = "d3b5e690-dfd5-4bc8-95ac-ba8de3c4e768",
                Name = "Dates",
                VolumeInMlPer100Grams = 160.95,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 282,
                    Carbohydrates = 75.03,
                    Proteins = 2.45,
                    Fats = 0.39,
                    Fibres = 8,
                    IngredientId = "d3b5e690-dfd5-4bc8-95ac-ba8de3c4e768",
                },
            },
            new Ingredient
            {
                Id = "1625872a-a878-4e71-aae9-931a84c5e4bb",
                Name = "Figs dry",
                VolumeInMlPer100Grams = 158.78,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 249,
                    Carbohydrates = 63.87,
                    Proteins = 3.3,
                    Fats = 0.93,
                    Fibres = 9.8,
                    IngredientId = "1625872a-a878-4e71-aae9-931a84c5e4bb",
                },
            },
            new Ingredient
            {
                Id = "976a13c0-a6c0-4088-a99f-fbc0864b67c0",
                Name = "Figs",
                VolumeInMlPer100Grams = 157.72,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 74,
                    Carbohydrates = 19.18,
                    Proteins = 0.75,
                    Fats = 0.3,
                    Fibres = 2.9,
                    IngredientId = "976a13c0-a6c0-4088-a99f-fbc0864b67c0",
                },
            },
            new Ingredient
            {
                Id = "354ce8e5-c26e-4c4e-b5b9-82f95fa8a785",
                Name = "Avocado",
                VolumeInMlPer100Grams = 157.73,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 160,
                    Carbohydrates = 8.53,
                    Proteins = 2,
                    Fats = 14.66,
                    Fibres = 6.70,
                    IngredientId = "354ce8e5-c26e-4c4e-b5b9-82f95fa8a785",
                },
            },
            new Ingredient
            {
                Id = "ff26afc9-b85c-4c7f-91b6-195e9e6c3b81",
                Name = "Red lentils",
                VolumeInMlPer100Grams = 124.53,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 358,
                    Carbohydrates = 63.10,
                    Proteins = 23.91,
                    Fats = 2.17,
                    Fibres = 10.8,
                    IngredientId = "ff26afc9-b85c-4c7f-91b6-195e9e6c3b81",
                },
            },
            new Ingredient
            {
                Id = "6b199064-f9ae-47ce-9deb-503b27f75ca1",
                Name = "Apples",
                VolumeInMlPer100Grams = 200.4,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 52,
                    Carbohydrates = 13.81,
                    Proteins = 0.26,
                    Fats = 0.17,
                    Fibres = 2.4,
                    IngredientId = "6b199064-f9ae-47ce-9deb-503b27f75ca1",
                },
            },
            new Ingredient
            {
                Id = "5b8c7c99-fec5-447e-9fb1-d8defb734ce1",
                Name = "Apricots",
                VolumeInMlPer100Grams = 124.53,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 48,
                    Carbohydrates = 11.12,
                    Proteins = 1.4,
                    Fats = 0.39,
                    Fibres = 2,
                    IngredientId = "5b8c7c99-fec5-447e-9fb1-d8defb734ce1",
                },
            },
            new Ingredient
            {
                Id = "4e5bd48e-f08d-46b5-9fcd-f8461ac85622",
                Name = "Mushrooms",
                VolumeInMlPer100Grams = 236.41,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 335,
                    Carbohydrates = 71.6,
                    Proteins = 9,
                    Fats = 4.2,
                    Fibres = 14.1,
                    IngredientId = "4e5bd48e-f08d-46b5-9fcd-f8461ac85622",
                },
            },
            new Ingredient
            {
                Id = "576660ba-8c5c-4134-b654-f2a1e6d9e423",
                Name = "Pasta",
                VolumeInMlPer100Grams = 236.41,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 348,
                    Carbohydrates = 71,
                    Proteins = 12,
                    Fats = 1.1,
                    Fibres = 3,
                    IngredientId = "576660ba-8c5c-4134-b654-f2a1e6d9e423",
                },
            },
            new Ingredient
            {
                Id = "0fb9eab7-271e-4f84-8bfe-ccfa5dfea76b",
                Name = "Cheese white",
                VolumeInMlPer100Grams = 105.15,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 238,
                    Carbohydrates = 3,
                    Proteins = 16,
                    Fats = 18,
                    Fibres = 0,
                    IngredientId = "0fb9eab7-271e-4f84-8bfe-ccfa5dfea76b",
                },
            },
            new Ingredient
            {
                Id = "55a70d9f-02de-4910-a88e-36c8638f3f85",
                Name = "Cheese yellow",
                VolumeInMlPer100Grams = 105.15,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 386,
                    Carbohydrates = 2,
                    Proteins = 27,
                    Fats = 30,
                    Fibres = 0,
                    IngredientId = "55a70d9f-02de-4910-a88e-36c8638f3f85",
                },
            },
            new Ingredient
            {
                Id = "22978802-324c-47a7-9b86-7ed815e79eaf",
                Name = "Cheddar Cheese",
                VolumeInMlPer100Grams = 100.71,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 394,
                    Carbohydrates = 0.1,
                    Proteins = 27.10,
                    Fats = 31.70,
                    Fibres = 0,
                    IngredientId = "22978802-324c-47a7-9b86-7ed815e79eaf",
                },
            },
            new Ingredient
            {
                Id = "2ee35e3d-83cd-4520-a386-aa723c11168f",
                Name = "Flax seed",
                VolumeInMlPer100Grams = 120,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 461,
                    Carbohydrates = 28.88,
                    Proteins = 24.4,
                    Fats = 30.9,
                    Fibres = 27.30,
                    IngredientId = "2ee35e3d-83cd-4520-a386-aa723c11168f",
                },
            },
            new Ingredient
            {
                Id = "2fa8a3a5-86f2-4951-b1f5-1585bd7ff90e",
                Name = "Chickpeas boiled",
                VolumeInMlPer100Grams = 139.08,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 164,
                    Carbohydrates = 27.42,
                    Proteins = 8.86,
                    Fats = 2.59,
                    Fibres = 7.6,
                    IngredientId = "2fa8a3a5-86f2-4951-b1f5-1585bd7ff90e",
                },
            },
            new Ingredient
            {
                Id = "15375c7e-603f-4a95-bcf8-2486204045e8",
                Name = "Carrots",
                VolumeInMlPer100Grams = 215.08,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 41,
                    Carbohydrates = 9.58,
                    Proteins = 0.93,
                    Fats = 0.24,
                    Fibres = 2.80,
                    IngredientId = "15375c7e-603f-4a95-bcf8-2486204045e8",
                },
            },
            new Ingredient
            {
                Id = "caf881c8-449e-4fff-a3f6-53558dd78a57",
                Name = "Onions",
                VolumeInMlPer100Grams = 133.33,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 40,
                    Carbohydrates = 9.3,
                    Proteins = 1.1,
                    Fats = 0.1,
                    Fibres = 1.7,
                    IngredientId = "caf881c8-449e-4fff-a3f6-53558dd78a57",
                },
            },
            new Ingredient
            {
                Id = "f469c9a1-d72f-4489-8975-3ecc380174f4",
                Name = "Coconut sugar",
                VolumeInMlPer100Grams = 184.83,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 380,
                    Carbohydrates = 92.6,
                    Proteins = 1,
                    Fats = 0,
                    Fibres = 0,
                    IngredientId = "f469c9a1-d72f-4489-8975-3ecc380174f4",
                },
            },
            new Ingredient
            {
                Id = "0afa5c59-2b80-444f-a871-7d717b819d2d",
                Name = "Raspberries",
                VolumeInMlPer100Grams = 145.42,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 52,
                    Carbohydrates = 11.9,
                    Proteins = 1.2,
                    Fats = 0.7,
                    Fibres = 6.5,
                    IngredientId = "0afa5c59-2b80-444f-a871-7d717b819d2d",
                },
            },
            new Ingredient
            {
                Id = "fb109688-6e1c-4520-82f6-f0f789ce4e12",
                Name = "Raspberries frozen",
                VolumeInMlPer100Grams = 189.39,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 52,
                    Carbohydrates = 11.9,
                    Proteins = 1.2,
                    Fats = 0.7,
                    Fibres = 6.5,
                    IngredientId = "fb109688-6e1c-4520-82f6-f0f789ce4e12",
                },
            },
            new Ingredient
            {
                Id = "be26588f-71dd-4afe-a3ac-1ff5c0dfa625",
                Name = "Nutmeg",
                VolumeInMlPer100Grams = 211.24,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 525,
                    Carbohydrates = 49.3,
                    Proteins = 5.8,
                    Fats = 36.3,
                    Fibres = 20.8,
                    IngredientId = "be26588f-71dd-4afe-a3ac-1ff5c0dfa625",
                },
            },
            new Ingredient
            {
                Id = "c5c813cc-725d-4297-8669-c0f5134a54f4",
                Name = "Cumin",
                VolumeInMlPer100Grams = 246.45,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 375,
                    Carbohydrates = 44.2,
                    Proteins = 17.8,
                    Fats = 22.3,
                    Fibres = 10.5,
                    IngredientId = "c5c813cc-725d-4297-8669-c0f5134a54f4",
                },
            },
            new Ingredient
            {
                Id = "fac7fc02-ee17-4200-a557-e873e69f3015",
                Name = "Curry",
                VolumeInMlPer100Grams = 234.71,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 325,
                    Carbohydrates = 55.8,
                    Proteins = 14.3,
                    Fats = 14,
                    Fibres = 53.2,
                    IngredientId = "fac7fc02-ee17-4200-a557-e873e69f3015",
                },
            },
            new Ingredient
            {
                Id = "18cba7e5-9280-47a7-b35b-c16d53131274",
                Name = "Turmeric",
                VolumeInMlPer100Grams = 157.31,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 312,
                    Carbohydrates = 67.1,
                    Proteins = 9.7,
                    Fats = 3.3,
                    Fibres = 22.7,
                    IngredientId = "18cba7e5-9280-47a7-b35b-c16d53131274",
                },
            },
            new Ingredient
            {
                Id = "93076c8f-d63d-4572-b017-1ee0090ae3e2",
                Name = "Bay leaf",
                VolumeInMlPer100Grams = 213.56,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 313,
                    Carbohydrates = 75,
                    Proteins = 7.6,
                    Fats = 8.4,
                    Fibres = 26.3,
                    IngredientId = "93076c8f-d63d-4572-b017-1ee0090ae3e2",
                },
            },
            new Ingredient
            {
                Id = "1a15807b-060d-4311-a494-cbc06fa5bcb0",
                Name = "Vinegar cider",
                VolumeInMlPer100Grams = 98.99,
                NutritionPer100Grams = new Nutrition
                {
                    Calories = 21,
                    Carbohydrates = 0.9,
                    Proteins = 5.8,
                    Fats = 36.3,
                    Fibres = 20.8,
                    IngredientId = "1a15807b-060d-4311-a494-cbc06fa5bcb0",
                },
            },
        };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Ingredients.Any(x => x.IsDeleted == false))
            {
                return;
            }

            foreach (var ingredient in this.ingredientsToAdd)
            {
                await dbContext.Ingredients.AddAsync(ingredient);
            }
        }
    }
}
