namespace PrintecExam.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using PrintecExam.Data;
    using PrintecExam.Data.Models;
    using PrintecExam.Services.Models;

    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext _context;

        public CarsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CarCreateServiceModel input)
        {
            var car = new Car
            {
                OwnerName = input.OwnerName,
                RegistrationPlate = input.RegistrationPlate,
                CubicCapacity = input.CubicCapacity,
                Color = input.Color,
                HorsePower = input.HorsePower,
                MakeId = input.MakeId,
                ModelId = input.ModelId,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var car = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            car.IsDeleted = true;
            car.DeletedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(CarEditServiceModel input)
        {
            var car = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (car != null && car.IsDeleted == false)
            {
                car.OwnerName = input.OwnerName;
                car.RegistrationPlate = input.RegistrationPlate;
                car.HorsePower = input.HorsePower;
                car.CubicCapacity = input.CubicCapacity;
                car.Color = input.Color;
                car.ModifiedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public IEnumerable<CarServiceModel> GetAll()
        {
            var cars = _context.Cars
                .Where(x => x.IsDeleted == false)
                .Select(c => new CarServiceModel
                {
                    Id = c.Id,
                    OwnerName = c.OwnerName,
                    RegistrationPlate = c.RegistrationPlate,
                    HorsePower = c.HorsePower,
                    Color = c.Color,
                    CubicCapacity = c.CubicCapacity,
                    MakeName = c.Make.Name,
                    ModelName = c.Model.Name,
                })
                .ToList();

            return cars;
        }

        public IEnumerable<CarServiceModel> GetAllByMake(string make)
        {
            var cars = new List<CarServiceModel>();

            if (make == "all")
            {
                cars = GetAll().ToList();
            }
            else
            {
                cars = _context.Cars
                .Where(x => x.IsDeleted == false && x.Make.Name == make)
                .Select(c => new CarServiceModel
                {
                    Id = c.Id,
                    OwnerName = c.OwnerName,
                    RegistrationPlate = c.RegistrationPlate,
                    HorsePower = c.HorsePower,
                    Color = c.Color,
                    CubicCapacity = c.CubicCapacity,
                    MakeName = c.Make.Name,
                    ModelName = c.Model.Name,
                })
                .ToList();
            }

            return cars;
        }

        public CarServiceModel GetById(string id)
        {
            var car = _context.Cars
                .Where(x => x.IsDeleted == false && x.Id == id)
                .Select(c => new CarServiceModel
                {
                    Id = c.Id,
                    OwnerName = c.OwnerName,
                    RegistrationPlate = c.RegistrationPlate,
                    HorsePower = c.HorsePower,
                    Color = c.Color,
                    CubicCapacity = c.CubicCapacity,
                    MakeName = c.Make.Name,
                    ModelName = c.Model.Name,
                })
                .FirstOrDefault();

            return car;
        }
    }
}
