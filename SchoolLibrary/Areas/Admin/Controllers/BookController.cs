using Microsoft.AspNetCore.Mvc;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Administrator;
using SchoolLibrary.Extension;

namespace SchoolLibrary.Areas.Admin.Controllers
{
    public class BookController : AdminBaseController
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public BookController(IBookService _bookService, IAuthorService _authorService)
        {
            bookService = _bookService;
            authorService = _authorService;
        }
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            var authorId = await authorService.GetAuthorIdAsync(userId) ?? 0;
            var myBooks = new MyBooksViewModel()
            {
                AddedBooks = await bookService.AllBooksByAuthorId(authorId),
                TakedBooks = await bookService.AllBooksByUserId(userId)
            };

            return View(myBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Approve()
        {
            var model = await bookService.GetUnApprovedAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int bookId)
        {
            await bookService.ApproveBookAsync(bookId);

            return RedirectToAction(nameof(Approve));

        }
    }
}
