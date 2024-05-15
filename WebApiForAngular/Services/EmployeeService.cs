using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiForAngular.Data.IRepositories;
using WebApiForAngular.IServices;
using WebApiForAngular.Models;

namespace WebApiForAngular.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;
        public EmployeeService(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }
        public async ValueTask<Employee> CreateAsync(Employee employee)
        {
           await _repository.CreateAsync(employee);
           await _repository.SaveChangesAsync();

            return employee;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await _repository.DeleteAsync(s=>s.Id == id);

            await _repository.SaveChangesAsync();
            if(isDelete)
                return isDelete;
            return false;
        }

        public async ValueTask<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> expression = null)
        {
            return await _repository.GetAllAsync(expression, includes: new string[]{ "Cars" }, isTracking: false).ToListAsync();
        }

        public async ValueTask<Employee> GetAsync(Expression<Func<Employee, bool>> expression)
        {
            return await _repository.GetAsync(expression, includes: new string[] { "Cars" });
        }

        public async ValueTask<Employee> UpdateAsync(int id, Employee employee)
        {
            var employeeOld = await _repository.GetAsync(d => d.Id == id);

            employeeOld.FirstName = employee.FirstName;
            employeeOld.LastName = employee.LastName;
            employeeOld.Phone = employee.Phone;
            employeeOld.Cars = employee.Cars;
            employeeOld.DepartmentId = employee.DepartmentId;

            await _repository.SaveChangesAsync();
           

            return employee;
        }
    }
}
