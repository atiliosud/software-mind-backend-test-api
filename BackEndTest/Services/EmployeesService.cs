using BackEndTest.Data;
using BackEndTest.Domain.TestDatabase;
using BackEndTest.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndTest.Services
{
    public class EmployeesService
    {
        private readonly EmployeeContext _context;

        public EmployeesService(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(CreateEmployeeRequest request)
        {
            try
            {
                var employee = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    HireDate = request.HireDate,
                    DepartmentId = request.DepartmentId,
                    Phone = request.Phone,
                    Address = request.Address
                };

                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            try
            {
                return await _context.Employees.Include(e => e.Department).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeById(int ID)
        {
            try
            {
                Employee employee = new Employee() { };

                var _employee = await _context.Employees.Include(e => e.Department)
                                                 .FirstOrDefaultAsync(e => e.Id == ID);

                if(_employee != null )
                {
                    employee = _employee;
                }

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Employee> UpdateEmployeeById(int id, UpdateEmployeeRequest request)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);

               if(employee != null )
                {
                    employee.FirstName = request.FirstName;
                    employee.LastName = request.LastName;
                    employee.HireDate = request.HireDate;
                    employee.DepartmentId = request.DepartmentId;
                    employee.Phone = request.Phone;
                    employee.Address = request.Address;
                }
                await _context.SaveChangesAsync();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> DeleteEmployeeById(int ID)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(ID);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                }

                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
