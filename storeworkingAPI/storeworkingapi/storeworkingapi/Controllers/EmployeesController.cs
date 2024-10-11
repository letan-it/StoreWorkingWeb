using Microsoft.AspNetCore.Mvc;
using storeworkingapi.Data;
using storeworkingapi.Models;
using storeworkingapi.Models.Domain;

namespace storeworkingapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;
        public EmployeesController(EmployeeDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var contacts = dbContext.Employees.ToList();
            return Ok(contacts);
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeRequestDTO request)
        {
            var domainModelEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
            };
            dbContext.Employees.Add(domainModelEmployee);
            dbContext.SaveChanges();
            return Ok(domainModelEmployee);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] Employee updatedEmployee)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null) return NotFound();

            employee.Name = updatedEmployee.Name;
            employee.Email = updatedEmployee.Email;
            employee.Phone = updatedEmployee.Phone;
            employee.Address = updatedEmployee.Address;
            dbContext.SaveChanges();
            return Ok(employee);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee != null)
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
            }

            return Ok();
        }

    }
}
