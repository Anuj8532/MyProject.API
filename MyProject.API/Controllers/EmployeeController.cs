using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services;
using MyProject.Domain.Entities;
using MyProject.Domain.Interface;

namespace MyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)

        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string employee_name = "", int page = 1, int pageSize = 2)
        {
            try
            {
                var emp = await _employeeService.GetEmployeeList(employee_name, page, pageSize);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("id")]
        public async Task<IActionResult>GetById(int id)
        {
            try
            {
                var emp = await _employeeService.GetEmployeeById(id);
                if (emp == null)
                    return NotFound();

                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create( Employee employee)
        {
            try
            {
                var createemp = await _employeeService.CreateEmployee(employee);
                return CreatedAtAction(nameof(GetById), new { id = createemp.ID }, createemp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            try
            {
                var existingemp = await _employeeService.UpdateEmployee(id, employee);
                if (existingemp == 0)
                    return BadRequest();

                return Ok(existingemp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dltemp = await _employeeService.DeleteEmployee(id);
                if (dltemp == 0)
                    return BadRequest();

                return Ok(dltemp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
