using System.Linq.Expressions;
using WebApiForAngular.Models;

namespace WebApiForAngular.IServices
{
    public interface IDepartmentService
    {
        ValueTask<Department> CreateAsync(Department department);

        ValueTask<Department> UpdateAsync(int id, Department department);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<Department> GetAsync(Expression<Func<Department, bool>> expression);

        ValueTask<IEnumerable<Department>> GetAllAsync(Expression<Func<Department, bool>> expression = null);
    }
}
