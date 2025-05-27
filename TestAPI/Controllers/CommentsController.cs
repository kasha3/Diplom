using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/v1/document/{documentId}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CommentsController(AppDbContext db) { _db = db; }

        [HttpGet]
        [Authorize]
        public IActionResult GetComments(int documentId)
        {
            var comments = _db.Comments.Where(c => c.DocumentId == documentId).ToList();
            if (comments.Count == 0) return NotFound();
            if (_db.Documents.Find(documentId).HasComments == false) return NotFound();
            return comments.Any() ? Ok(comments) : NotFound(new { message = "Не найдены комментарии для документа" });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddComment(int documentId, [FromBody] Comment comment)
        {
            comment.DocumentId = documentId;
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return Ok(comment);
        }
    }
}
