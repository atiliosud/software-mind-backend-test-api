using BackEndTest.Models;
using BackEndTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentsService _service;

        public DepartmentsController(DepartmentsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _service.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _service.GetDepartmentById(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentRequest request)
        {
            var department = await _service.CreateDepartment(request);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }
    }
}
