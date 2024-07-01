using MyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeeList(string employee_name, int page, int pageSize);
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> CreateEmployee(Employee employee);
        Task<int> UpdateEmployee(int id, Employee employee);
        Task<int> DeleteEmployee(int id);
    }
}
