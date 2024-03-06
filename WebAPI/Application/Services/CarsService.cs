using System;
using WebAPI.Application.Interfaces;
using WebAPI.Infrastructure.Repository;
using WebAPI.Models;

namespace WebAPI.Application.Services
{
	public class CarsService : ICarsService
    {
		private readonly CarsRepository _carsRepository;

		public CarsService (CarsRepository carsRepository)
		{
			_carsRepository = carsRepository;
		}

		public async Task<IEnumerable<Car>> GetCars()
        {
			return await _carsRepository.GetAllCarsAsync();
		}

		public async Task<Car> GetCarById(int id)
		{
			return await _carsRepository.GetCarById(id);
		}

		public async Task<Car> AddCar(Car car)
		{
			return await _carsRepository.AddCarAsync(car);
		}

		public async Task<Car> UpdateCar (int id, Car car)
		{
			return await _carsRepository.UpdateCarAsync(id, car);
		}

		public async Task<bool> DeleteCar (int id)
		{
			return await _carsRepository.DeleteCarAsync(id);
		}
    }
}
