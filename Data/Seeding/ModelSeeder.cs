namespace PrintecExam.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using PrintecExam.Data.Models;

    public class ModelSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (!dbContext.Models.Any())
            {
                var models = new Dictionary<string, List<string>>();

                models.Add(
                    "Audi", new List<string>
                    {
                        "A2",
                        "A3",
                        "A4",
                        "A5",
                        "A6",
                        "A7",
                        "A8",
                        "Q3",
                        "Q5",
                        "Q7",
                    });
                models.Add(
                    "Alfa Romeo", new List<string>
                    {
                        "Brera",
                        "145",
                        "146",
                        "147",
                        "156",
                        "159",
                        "166",
                        "Stelvio",
                        "Giullia",
                        "Spider",
                        "Gtv",
                    });
                models.Add(
                    "Honda", new List<string>
                    {
                        "Civic",
                        "Jazz",
                        "Hrv",
                        "Prelude",
                        "Accord",
                    });
                models.Add(
                    "Toyota", new List<string>
                    {
                        "Yaris",
                        "Prius",
                        "Supra",
                        "Celica",
                        "Corolla",
                    });

                foreach (var model in models)
                {
                    var makeName = model.Key;

                    var currMake = await dbContext.Makes.FirstOrDefaultAsync(x => x.Name == makeName);

                    foreach (var currModel in model.Value)
                    {
                        await dbContext.Models.AddAsync(new Model
                        {
                            Name = currModel,
                            MakeId = currMake.Id,
                            CreatedOn = DateTime.UtcNow,
                        });
                    }
                }
            }
        }
    }
}
