using System;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;


namespace WebAPI.Infrastructure.Repository
{
	public class CarsRepository
	{
        private readonly ApplicationDbContext _context;

        public CarsRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }
        public async Task<Car> GetCarById(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCarAsync(int id, Car car)
        {
            if (id != car.CarID)
            {
                throw new ArgumentException("ID Mismatch");
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    throw new ArgumentException("Car not found");
                }
                else
                {
                    throw;
                }
            }
            return car;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return false;
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarID == id);
        }
    }
}

