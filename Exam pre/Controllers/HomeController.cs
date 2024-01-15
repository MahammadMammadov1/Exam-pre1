using Exam.Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Exam_pre.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDb;

        public HomeController(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public IActionResult Index()
        {
            var blogs = _appDb.Blogs.ToList();
            return View(blogs);
        }
    }
}
