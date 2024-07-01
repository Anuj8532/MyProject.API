using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;
using MyProject.Domain.Interface;
using MyProject.Infrastructure.Data;

namespace MyProject.Infrastructure.Repositery
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepo(EmployeeDbContext employeeDbContext) 
        {
            _employeeDbContext = employeeDbContext;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
           await _employeeDbContext.Employee.AddAsync(employee);
            await _employeeDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<int> DeleteEmployee(int id)
        {
           return await _employeeDbContext.Employee.Where(x=> x.ID == id).ExecuteDeleteAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeDbContext.Employee.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Employee>> GetEmployeeList(string employee_name, int page, int pageSize)
        {

            IQueryable<Employee> query = _employeeDbContext.Employee;

            if (!string.IsNullOrEmpty(employee_name))
            {
                query = query.Where(e => e.EmployeeName.Contains(employee_name));
            }

            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> UpdateEmployee(int id, Employee employee)
        {
            return await _employeeDbContext.Employee.Where(x => x.ID == id).ExecuteUpdateAsync(setters => setters.SetProperty(m => m.ID, employee.ID).SetProperty(m => m.EmployeeName, employee.EmployeeName).SetProperty(m => m.Salary, employee.Salary).SetProperty(m => m.Status, employee.Status).SetProperty(m => m.MobileNumber, employee.MobileNumber));
        }
    }
}
