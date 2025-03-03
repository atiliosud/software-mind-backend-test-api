using BackEndTest.Data;
using BackEndTest.Domain.TestDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndTest.Models;
using BackEndTest.Services;

namespace BackEndTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesService _service;

        public EmployeesController(EmployeesService employeesService)
        {
            _service = employeesService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeRequest request)
        {
            Employee employee = await _service.CreateEmployee(request);
        
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            List<Employee> employees = await _service.GetAllEmployee();
            return employees;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _service.GetEmployeeById(id);
            if (employee.Id == 0) return NotFound();

            return employee;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeRequest request)
        {
            var employee = await _service.UpdateEmployeeById(id, request);
            if (employee.Id == 0) return NotFound();


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _service.DeleteEmployeeById(id);
            if (employee.Id == 0) return NotFound();

            return NoContent();
        }
    }

}
