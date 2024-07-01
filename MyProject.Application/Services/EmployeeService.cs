using MyProject.Domain.Entities;
using MyProject.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo) 
        { 
            _employeeRepo = employeeRepo;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            return await _employeeRepo.CreateEmployee(employee);
        }

        public async Task<int> DeleteEmployee(int id)
        {
           return await (_employeeRepo.DeleteEmployee(id));
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepo.GetEmployeeById(id);
        }

        public async Task<List<Employee>> GetEmployeeList(string employee_name, int page, int pageSize)
        {
           return await _employeeRepo.GetEmployeeList(employee_name, page, pageSize);
        }

        public async Task<int> UpdateEmployee(int id, Employee employee)
        {
            return await _employeeRepo.UpdateEmployee(id, employee);
        }
    }
}
