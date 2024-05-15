using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiForAngular.Data.IRepositories;
using WebApiForAngular.IServices;
using WebApiForAngular.Models;

namespace WebApiForAngular.Services
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _repository;
        public CarService(IGenericRepository<Car> repository) 
        {
           _repository = repository;
        }

        public async ValueTask<Car> CreateAsync(Car car)
        {
            await _repository.CreateAsync(car);
            await _repository.SaveChangesAsync();

            return car;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isdelete=await _repository.DeleteAsync(d=>d.Id==id);
            if(isdelete)
            {
                await _repository.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async ValueTask<IEnumerable<Car>> GetAllAsync(Expression<Func<Car, bool>> expression = null)
        {
            return await _repository.GetAllAsync(expression).ToListAsync();
        }

        public async ValueTask<Car> GetAsync(Expression<Func<Car, bool>> expression)
        {
            return await _repository.GetAsync(expression);
        }

        public async ValueTask<Car> UpdateAsync(int id, Car car)
        {
           var carOld= await _repository.GetAsync(d=> d.Id==id);

            carOld.Name=car.Name;
            carOld.Description=car.Description;
            carOld.EmployeeId=car.EmployeeId;          

            await _repository.SaveChangesAsync();

            return car;
        }
    }
}
