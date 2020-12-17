namespace CookLab.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Data.Models;
    using CookLab.Data.Models.Enums;

    internal class CookingVesselsSeeder : ISeeder
    {
        private List<CookingVessel> cookingVesselsToAdd = new List<CookingVessel>
        {
            new CookingVessel
            {
                Id = 1,
                Form = PanForm.Circle,
                Diameter = 20,
                Height = 7,
                Area = Math.PI * (20 / 2) * (20 / 2),
                Volume = Math.PI * (20 / 2) * (20 / 2) * 7,
                Name = "Circle 20cm/7cm",
            },
            new CookingVessel
            {
                Id = 2,
                Form = PanForm.Circle,
                Diameter = 22,
                Height = 7,
                Area = Math.PI * (22 / 2) * (22 / 2),
                Volume = Math.PI * (22 / 2) * (22 / 2) * 7,
                Name = "Circle 22cm/7cm",
            },
            new CookingVessel
            {
                Id = 3,
                Form = PanForm.Circle,
                Diameter = 25,
                Height = 7,
                Area = Math.PI * (25 / 2) * (25 / 2),
                Volume = Math.PI * (25 / 2) * (25 / 2) * 7,
                Name = "Circle 25cm/7cm",
            },
            new CookingVessel
            {
                Id = 4,
                Form = PanForm.Circle,
                Diameter = 26,
                Height = 7,
                Area = Math.PI * (26 / 2) * (26 / 2),
                Volume = Math.PI * (26 / 2) * (26 / 2) * 7,
                Name = "Circle 26cm/7cm",
            },
            new CookingVessel
            {
                Id = 5,
                Form = PanForm.Circle,
                Diameter = 20,
                Height = 20,
                Area = Math.PI * (20 / 2) * (20 / 2),
                Volume = Math.PI * (20 / 2) * (20 / 2) * 20,
                Name = "Circle 20cm/20cm",
            },
            new CookingVessel
            {
                Id = 6,
                Form = PanForm.Circle,
                Diameter = 25,
                Height = 20,
                Area = Math.PI * (25 / 2) * (25 / 2),
                Volume = Math.PI * (25 / 2) * (25 / 2) * 20,
                Name = "Circle 25cm/20cm",
            },
            new CookingVessel
            {
                Id = 7,
                Form = PanForm.Circle,
                Diameter = 30,
                Height = 20,
                Area = Math.PI * (30 / 2) * (30 / 2),
                Volume = Math.PI * (30 / 2) * (30 / 2) * 20,
                Name = "Circle 30cm/20cm",
            },
            new CookingVessel
            {
                Id = 8,
                Form = PanForm.Circle,
                Diameter = 25,
                Height = 25,
                Area = Math.PI * (25 / 2) * (25 / 2),
                Volume = Math.PI * (25 / 2) * (25 / 2) * 25,
                Name = "Circle 25cm/25cm",
            },
            new CookingVessel
            {
                Id = 9,
                Form = PanForm.Circle,
                Diameter = 30,
                Height = 30,
                Area = Math.PI * (30 / 2) * (30 / 2),
                Volume = Math.PI * (30 / 2) * (30 / 2) * 30,
                Name = "Circle 30cm/30cm",
            },
            new CookingVessel
            {
                Id = 10,
                Form = PanForm.Square,
                SideA = 18,
                Height = 7,
                Area = 18 * 18,
                Volume = 18 * 18 * 7,
                Name = "Square 18x18cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 11,
                Form = PanForm.Square,
                SideA = 20,
                Height = 7,
                Area = 20 * 20,
                Volume = 20 * 20 * 7,
                Name = "Square 20x20cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 12,
                Form = PanForm.Square,
                SideA = 25,
                Height = 7,
                Area = 25 * 25,
                Volume = 25 * 25 * 7,
                Name = "Square 25x25cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 13,
                Form = PanForm.Square,
                SideA = 30,
                Height = 7,
                Area = 30 * 30,
                Volume = 30 * 30 * 7,
                Name = "Square 30x30cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 14,
                Form = PanForm.Rectangular,
                SideA = 15,
                SideB = 20,
                Height = 7,
                Area = 15 * 20,
                Volume = 15 * 20 * 7,
                Name = "Rectangular 15x20cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 15,
                Form = PanForm.Rectangular,
                SideA = 15,
                SideB = 25,
                Height = 7,
                Area = 15 * 25,
                Volume = 15 * 25 * 7,
                Name = "Rectangular 15x25cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 16,
                Form = PanForm.Rectangular,
                SideA = 15,
                SideB = 30,
                Height = 7,
                Area = 15 * 30,
                Volume = 15 * 30 * 7,
                Name = "Rectangular 15x30cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 17,
                Form = PanForm.Rectangular,
                SideA = 18,
                SideB = 20,
                Height = 7,
                Area = 18 * 20,
                Volume = 18 * 20 * 7,
                Name = "Rectangular 18x20cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 18,
                Form = PanForm.Rectangular,
                SideA = 18,
                SideB = 25,
                Height = 7,
                Area = 18 * 25,
                Volume = 18 * 25 * 7,
                Name = "Rectangular 18x25cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 19,
                Form = PanForm.Rectangular,
                SideA = 18,
                SideB = 30,
                Height = 7,
                Area = 18 * 30,
                Volume = 18 * 30 * 7,
                Name = "Rectangular 18x30cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 20,
                Form = PanForm.Rectangular,
                SideA = 18,
                SideB = 35,
                Height = 7,
                Area = 18 * 35,
                Volume = 18 * 35 * 7,
                Name = "Rectangular 18x35cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 21,
                Form = PanForm.Rectangular,
                SideA = 20,
                SideB = 25,
                Height = 7,
                Area = 20 * 25,
                Volume = 20 * 25 * 7,
                Name = "Rectangular 20x25cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 22,
                Form = PanForm.Rectangular,
                SideA = 20,
                SideB = 30,
                Height = 7,
                Area = 20 * 30,
                Volume = 20 * 30 * 7,
                Name = "Rectangular 20x30cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 23,
                Form = PanForm.Rectangular,
                SideA = 25,
                SideB = 30,
                Height = 7,
                Area = 25 * 30,
                Volume = 25 * 30 * 7,
                Name = "Rectangular 25x30cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 24,
                Form = PanForm.Rectangular,
                SideA = 25,
                SideB = 35,
                Height = 7,
                Area = 25 * 35,
                Volume = 25 * 35 * 7,
                Name = "Rectangular 25x35cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 25,
                Form = PanForm.Rectangular,
                SideA = 25,
                SideB = 40,
                Height = 7,
                Area = 25 * 40,
                Volume = 25 * 40 * 7,
                Name = "Rectangular 25x40cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 26,
                Form = PanForm.Custom,
                Height = 7,
                Area = 325,
                Volume = 325 * 7,
                Name = "Heart 325cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 27,
                Form = PanForm.Custom,
                Height = 7,
                Area = 325,
                Volume = 325 * 7,
                Name = "Heart 325cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 28,
                Form = PanForm.Custom,
                Height = 7,
                Area = 400,
                Volume = 400 * 7,
                Name = "Heart 400cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 29,
                Form = PanForm.Custom,
                Height = 7,
                Area = 350,
                Volume = 350 * 7,
                Name = "Butterfly 325cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 30,
                Form = PanForm.Custom,
                Height = 7,
                Area = 450,
                Volume = 450 * 7,
                Name = "Triangle 450cm\xB2/7cm",
            },
            new CookingVessel
            {
                Id = 31,
                Form = PanForm.Circle,
                Diameter = 20,
                Height = 10,
                Area = Math.PI * (20 / 2) * (20 / 2),
                Volume = Math.PI * (20 / 2) * (20 / 2) * 10,
                Name = "Circle 20cm/7cm",
            },
        };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CookingVessels.Any(x => x.IsDeleted == false))
            {
                return;
            }

            foreach (var cookingVessel in this.cookingVesselsToAdd)
            {
                await dbContext.CookingVessels.AddAsync(cookingVessel);
            }
        }
    }
}
