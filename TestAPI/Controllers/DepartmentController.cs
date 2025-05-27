using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/v1/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public DepartmentController(AppDbContext db) { _db = db; }

        [HttpGet]
        public IActionResult GetDepartment() => Ok(_db.departaments.ToList());
    }
}
