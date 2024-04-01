using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolLibrary.Core.Models.Book;

namespace SchoolLibrary.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllBooksQueryModel();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllBooksQueryModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new BookDetailsViewModel();
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id= 1});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new BookFormModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,BookFormModel model)
        { 
            return RedirectToAction(nameof(Details), new { id= 1});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new BookDetailsViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, BookDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> GetABook(int id)
        {
            return RedirectToAction(nameof(Mine));
        }


        [HttpPost]
        public async Task<IActionResult> TakeBackTheBook(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
