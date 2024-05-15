using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiForAngular.IServices;
using WebApiForAngular.Models;

namespace WebApiForAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService service)
        {
            _departmentService = service;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _departmentService.GetAsync(d => d.Id == id));
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll()
        {
            return Ok(await _departmentService.GetAllAsync());
        }

        [HttpPost("Create")]
        public async ValueTask<IActionResult> Post([FromBody] Department department)
        {
            return Ok(await _departmentService.CreateAsync(department));
        }

        [HttpPut("Update/{id}")]
        public async ValueTask<IActionResult> Put(int id, [FromBody] Department department)
        {
            return Ok(await _departmentService.UpdateAsync(id, department));
        }

        [HttpDelete("Delete/{id}")]
        public async ValueTask<IActionResult> Delete(int id)
        {
            return Ok(await _departmentService.DeleteAsync(id));
        }
    }
}
