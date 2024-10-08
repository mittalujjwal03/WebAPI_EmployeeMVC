using Microsoft.AspNetCore.Mvc;

using EmployeeCRUD.Models;
using BusinessLogicLayer.IServices;

namespace EmployeeCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _service.GetById(id);
            return department == null ? NotFound() : Ok(department);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Department department)
        {
            _service.Add(department);
            return CreatedAtAction(nameof(GetById), new { id = department.DepartmentId }, department);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Department department)
        {
            if (id != department.DepartmentId) return BadRequest();
            _service.Update(department);
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
