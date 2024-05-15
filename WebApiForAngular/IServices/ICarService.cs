using System.Linq.Expressions;
using WebApiForAngular.Models;

namespace WebApiForAngular.IServices
{
    public interface ICarService
    {
        ValueTask<Car> CreateAsync(Car car);

        ValueTask<Car> UpdateAsync(int id, Car car);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<Car> GetAsync(Expression<Func<Car, bool>> expression);

        ValueTask<IEnumerable<Car>> GetAllAsync(Expression<Func<Car, bool>> expression = null);
    }
}
