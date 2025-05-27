using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/v1/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public DocumentsController(AppDbContext db) { _db = db; }
        [HttpGet]
        [Authorize]
        public IActionResult GetDocuments() => Ok(_db.Documents.ToList());
    }
}
