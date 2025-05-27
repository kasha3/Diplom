using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EmployeesController(AppDbContext db) { _db = db; }

        [HttpGet("web")]
        public IActionResult GetEmployees()
        {
            var employees = _db.employees
                .Select(e => new
                {
                    e.Id,
                    e.FullName,
                    e.Position.Name,
                    e.Email,
                    e.WorkPhone,
                    Birthdate = _db.employees.FirstOrDefault(x => x.Id == e.Id).BirthDate.ToString("M") // по формату: day month
                }).ToList();

            return Ok(employees);
        }
        [HttpGet("desktop")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_db.employees.ToList());
        }

        [HttpPost]
        public IActionResult PostEmployee([FromBody] Employees emp) 
        {
            if (emp == null)
            {
                return BadRequest("Invalid data.");
            }
            try
            {
                _db.employees.Add(emp);
                _db.SaveChanges();

                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employees updatedEmployee)
        {
            if (updatedEmployee == null || id != updatedEmployee.Id)
            {
                return BadRequest("Invalid data.");
            }

            var employee = _db.employees.Find(id);
            if (employee == null)
            {
                return NotFound("Employee with this id not found.");
            }

            employee.PositionId = updatedEmployee.PositionId;
            employee.FullName = updatedEmployee.FullName;
            employee.BirthDate = updatedEmployee.BirthDate;
            employee.WorkPhone = updatedEmployee.WorkPhone;
            employee.Office = updatedEmployee.Office;
            employee.Email = updatedEmployee.Email;
            employee.MobilePhone = updatedEmployee.MobilePhone;
            employee.DirectorId = updatedEmployee.DirectorId;
            employee.AssistantId = updatedEmployee.AssistantId;
            employee.TerminationDate = updatedEmployee.TerminationDate;
            try
            {
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
