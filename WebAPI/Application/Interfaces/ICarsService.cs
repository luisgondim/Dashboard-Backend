using System;
using WebAPI.Models;

namespace WebAPI.Application.Interfaces
{
	public interface ICarsService
	{
		Task<IEnumerable<Car>> GetCars();
		Task<Car> GetCarById(int id);
		Task<Car> AddCar(Car car);
		Task<Car> UpdateCar(int id, Car car);
		Task<bool> DeleteCar(int id);
	}
}

