using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/v1/organizations")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public OrganizationsController(AppDbContext db) {  _db = db; }

        [HttpGet]
        public IActionResult GetOrganizations() { return Ok(_db.organizations.ToList()); }
    }
}
