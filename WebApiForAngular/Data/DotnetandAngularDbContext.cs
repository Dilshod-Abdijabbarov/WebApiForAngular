using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiForAngular.Models;

namespace WebApiForAngular.Data
{
    public class DotnetandAngularDbContext : DbContext
    {
        public DotnetandAngularDbContext(DbContextOptions<DotnetandAngularDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }       
    }
}
