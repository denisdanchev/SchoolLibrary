using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Book;
using SchoolLibrary.Extension;

namespace SchoolLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public BookController(IBookService _bookService, IAuthorService _authorService)
        {
            bookService = _bookService;
            authorService = _authorService;

        }
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
        public async Task<IActionResult> Add()
        {
            if (await authorService.ExistByIdAsync(User.Id()) == false)
            {
                return RedirectToAction(nameof(AuthorController.BeAuthor), "Author");
            }

            var model = new BookFormModel()
            {
                Genres = await bookService.AllGenresAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel model)
        {
            if (await authorService.ExistByIdAsync(User.Id()) == false)
            {
                return RedirectToAction(nameof(AuthorController.BeAuthor), "Author");
            }

            if (await bookService.GenreExistAsync(model.GenreId) == false)
            {
                ModelState.AddModelError(nameof(model.GenreId), "");
            }

            if (ModelState.IsValid == false)
            { 
                model.Genres = await bookService.AllGenresAsync();

                return View(model);
            }

            int? authorId = await authorService.GetAuthorIdAsync(User.Id());

            int newBookId = await bookService.CreateAsyc(model, authorId ?? 0);

            return RedirectToAction(nameof(Details), new { id = newBookId });
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
