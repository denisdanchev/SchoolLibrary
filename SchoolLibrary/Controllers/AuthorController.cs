using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Author;
using SchoolLibrary.Extension;

namespace SchoolLibrary.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService _authorService)
        {
            authorService = _authorService;
        }

        [HttpGet]
        public async Task<IActionResult> BeAuthor()
        {
            if (await authorService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

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
