using Microsoft.AspNetCore.Mvc;
using WebApiForAngular.IServices;
using WebApiForAngular.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiForAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService) 
        {
        _carService = carService;
        }
        // GET: api/<CarController>
        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            return Ok(await _carService.GetAllAsync());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _carService.GetAsync(d=>d.Id==id));
        }

        // POST api/<CarController>
        [HttpPost("Create")]
        public async ValueTask<IActionResult> Post([FromBody] Car car)
        {
            return Ok(await _carService.CreateAsync(car));
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> Put(int id, [FromBody] Car car)
        {
            var carOld=await _carService.GetAsync(d=> d.Id==id);

            carOld = await _carService.UpdateAsync(id, car);

            return Ok(car);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete(int id)
        {
            return Ok(await _carService.DeleteAsync(id));

        }
    }
}
