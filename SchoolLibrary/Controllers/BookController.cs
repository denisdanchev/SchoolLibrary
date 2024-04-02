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
        public async Task<IActionResult> All([FromQuery]AllBooksQueryModel query)
        {
            var model = await bookService.AllAsync(
                query.Genre,
                query.SearchTerm,
                query.Sorting,
                query.CurentPage,
                query.BooksPerPage);

            query.TotalBooksCount = model.TotalBooksCount;
            query.Books = model.Books;
            query.Genres = await bookService.AllGenresNamesAsync();

            return View(query);
        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<BookServiceModel> model;

            if (await authorService.ExistByIdAsync(userId))
            {
                int authorId = await authorService.GetAuthorIdAsync(userId) ?? 0;
                model = await bookService.AllBooksByAuthorId(authorId);
            }
            else
            {
                model = await bookService.AllBooksByUserId(userId);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await bookService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await bookService.BookDetailsByIdAsync(id);
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
                ModelState.AddModelError(nameof(model.GenreId), "Genre does not exist");
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
            if (await bookService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await bookService.HasAuthorWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await bookService.GetBookFormModelByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,BookFormModel model)
        {
            if (await bookService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await bookService.HasAuthorWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await bookService.GenreExistAsync(model.GenreId) == false)
            {
                ModelState.AddModelError(nameof(model.GenreId), "Genre does not exist");
            }
            if (ModelState.IsValid == false)
            {
                model.Genres = await bookService.AllGenresAsync();

                return View(model);
            }
            await bookService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id});

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await bookService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await bookService.HasAuthorWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var book = await bookService.BookDetailsByIdAsync(id);

            var model = new BookDetailsViewModel()
            {
                Id = id,
                LocationInLibrary = book.PositionInLibrary,
                ImageUrl = book.ImageUrl,
                BookTitle = book.Title,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(BookDetailsViewModel model)
        {
            if (await bookService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await bookService.HasAuthorWithIdAsync(model.Id, User.Id()) == false)
            {
                return Unauthorized();
            }

            await bookService.DeleteAsync(model.Id);
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
