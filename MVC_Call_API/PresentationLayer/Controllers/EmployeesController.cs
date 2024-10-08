using Microsoft.AspNetCore.Mvc;

using EmployeeCRUD.Models;
using BusinessLogicLayer.IServices;

namespace EmployeeCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _service.GetById(id);
            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Employee employee)
        {
            _service.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeId) return BadRequest();
            _service.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
