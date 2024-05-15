using System.Linq.Expressions;
using WebApiForAngular.Models;

namespace WebApiForAngular.IServices
{
    public interface IEmployeeService
    {
        ValueTask<Employee> CreateAsync(Employee employee);

        ValueTask<Employee> UpdateAsync(int id, Employee employee);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<Employee> GetAsync(Expression<Func<Employee, bool>> expression);

        ValueTask<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> expression = null);
    }
}

