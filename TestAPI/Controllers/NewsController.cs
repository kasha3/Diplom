using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/v1/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public NewsController(AppDbContext db) { _db = db; }

        [HttpGet]
        public IActionResult GetNews()
        {
            var news = _db.news
                .OrderByDescending(n => n.Date)
                .Select(n => new
                {
                    n.Id,
                    n.Name,
                    Date = _db.news.FirstOrDefault(x => x.Id == n.Id).Date.ToString("dd.MM.yyyy"),
                    n.Description,
                    n.Image,
                    n.Likes,
                    n.Dislikes
                });
            return Ok(news);
        }
    }
}
