using Microsoft.AspNetCore.Mvc;
using WebApiForAngular.IServices;
using WebApiForAngular.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiForAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }
        // GET: api/<EmployeeController>
        [HttpGet("GetById{id}")]
        public async ValueTask<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _employeeService.GetAsync(d => d.Id == id));
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll()
        {
           return Ok(await _employeeService.GetAllAsync());
        }

        // POST api/<EmployeeController>
        [HttpPost("Create")]
        public async ValueTask<IActionResult> Post([FromBody] Employee employee)
        {
            return Ok(await _employeeService.CreateAsync(employee));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("Update")]
        public async ValueTask<IActionResult> Update([FromQuery]int id, [FromBody] Employee employee)
        {
            return Ok(await _employeeService.UpdateAsync(id, employee));
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("Delete/{id}")]
        public async ValueTask<IActionResult> Delete(int id)
        {
            return Ok(await _employeeService.DeleteAsync(id));
        }
    }
}
