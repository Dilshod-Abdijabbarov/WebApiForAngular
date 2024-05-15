namespace WebApiForAngular.Models
{
    public class Department
    {
        public int Id { get; set; } 
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
    
}
