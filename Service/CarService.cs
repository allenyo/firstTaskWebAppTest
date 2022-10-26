﻿using Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class CarService : ICarService
    {
        private readonly carsContext _carsContext;

        public CarService(carsContext carsContext)
        {
            _carsContext = carsContext;
        }

        public async Task<bool> Add(Car car)
        {
           await _carsContext.Cars.AddAsync(car);  
            await _carsContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Car car)
        {
            _carsContext.Cars.Remove(car);
            await _carsContext.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Car>> GetAll()
        {
            return await _carsContext.Cars.ToListAsync();
        }

        public async Task<Car?> GetById(int id)
        {
           return await _carsContext.Cars.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Car>> GetbyMake(string makeName)
        {
            return await _carsContext.Cars.Where(m => m.Make == makeName).ToListAsync();
        }

        public async Task<IList<Car>> GetByModel(string name)
        {
            return await _carsContext.Cars.Where(m => m.Model == name).ToListAsync();
        }

        public async Task<bool> Update(Car car)
        {
           _carsContext.Cars.Update(car);
            await _carsContext.SaveChangesAsync();
            return true;
        }
    }
}