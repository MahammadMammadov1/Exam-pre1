using Exam.Business.CustomExceptions;
using Exam.Business.Service.Interfaces;
using Exam.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam_pre.Areas.manage.Controllers
{
    [Area("manage")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            var blog  = await _blogService.GetAllAsync();
            return View(blog);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog) 
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _blogService.CreateAsync(blog);
            }
            catch (ContentTypeException ex)
            {
                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }
                
            
            
           

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var blg = await _blogService.GetByIdAsync(id);
            return View(blg);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Blog blog)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                await _blogService.UpdateAsync(blog);
            }
            catch (ContentTypeException ex)
            {
                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }
            

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) 
        {
            await _blogService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
