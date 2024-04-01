using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolLibrary.Core.Models.Author;

namespace SchoolLibrary.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> BeAuthor()
        {
            var model = new BeAuthorFormModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> BeAuthor(BeAuthorFormModel model)
        {
            return RedirectToAction(nameof(BookController.All), "Book");
        }
    }
}
