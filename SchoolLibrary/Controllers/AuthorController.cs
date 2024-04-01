using Microsoft.AspNetCore.Mvc;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Author;
using SchoolLibrary.Extension;
using static SchoolLibrary.Core.Constants.MessageConstants;
namespace SchoolLibrary.Controllers
{
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

            if (await authorService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            if (await authorService.UserWithThisNameExistAsync(User.Id()))
            {
                ModelState.AddModelError(nameof(model.AuthorName), AuthroNameExists);
            }

            if (await authorService.UserHasTakesAsync(User.Id()))
            {
                ModelState.AddModelError("Error",HasTakes);
            }

            if (ModelState.IsValid == false)
            { 
                return View(model);
            }

            await authorService.CreateAsync(User.Id(), model.AuthorName);

            return RedirectToAction(nameof(BookController.All), "Book");
        }
    }
}
