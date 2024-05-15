using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiForAngular.Data.IRepositories;
using WebApiForAngular.IServices;
using WebApiForAngular.Models;

namespace WebApiForAngular.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _repository;

        public DepartmentService(IGenericRepository<Department> repository)
        {
            _repository = repository;
        }

        public async ValueTask<Department> CreateAsync(Department department)
        {
            if(department.DepartmentName != "") 
            {
                await _repository.CreateAsync(department);
                await _repository.SaveChangesAsync();
            }
            

            await _repository.SaveChangesAsync();
            return department;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
         var IsDelete= await _repository.DeleteAsync(D=>D.Id == id);
            await _repository.SaveChangesAsync();
            if(IsDelete)
                return true;
            return false;
        }

        public async ValueTask<IEnumerable<Department>> GetAllAsync(Expression<Func<Department, bool>> expression = null)
        {
           return await _repository.GetAllAsync(expression,includes:new string[] {"Employees"},isTracking:false).ToListAsync();
        }

        public async ValueTask<Department> GetAsync(Expression<Func<Department, bool>> expression)
        {
            return await _repository.GetAsync(expression, includes: new string[]{ "Employees","Cars" });
        }

        public async ValueTask<Department> UpdateAsync(int id, Department department)
        {
            var departmentOld = await _repository.GetAsync(d => d.Id == id);
              
            departmentOld.DepartmentName=department.DepartmentName;
            departmentOld.Description=department.Description;
           
                await _repository.SaveChangesAsync();

                return department;
        }
    }
}
