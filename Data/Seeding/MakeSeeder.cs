namespace PrintecExam.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PrintecExam.Data.Models;

    public class MakeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (!dbContext.Makes.Any())
            {
                var makes = new List<string>
                {
                    "Audi",
                    "Alfa Romeo",
                    "Honda",
                    "Toyota",
                };

                foreach (var make in makes)
                {
                    await dbContext.Makes.AddAsync(new Make
                    {
                        Name = make,
                        CreatedOn = DateTime.UtcNow,
                    });
                }

            }
        }
    }
}
