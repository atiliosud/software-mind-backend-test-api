using BackEndTest.Data;
using BackEndTest.Domain.TestDatabase;
using BackEndTest.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndTest.Services
{
    public class DepartmentsService
    {
        private readonly EmployeeContext _context;

        public DepartmentsService(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentById(int id)
        {
            return await _context.Departments.Include(d => d.Employees)
                                             .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Department> CreateDepartment(CreateDepartmentRequest request)
        {
            var department = new Department
            {
                Name = request.Name
            };

            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return department;
        }
    }
}
