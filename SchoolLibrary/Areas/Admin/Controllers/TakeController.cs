using Microsoft.AspNetCore.Mvc;
using SchoolLibrary.Core.Contracts;

namespace SchoolLibrary.Areas.Admin.Controllers
{
    public class TakeController : AdminBaseController
    {
        private readonly ITakeService takeService;

        public TakeController(ITakeService _takeService)
        {
            takeService = _takeService;
        }

        public async Task<IActionResult> All()
        {
            var model = await takeService.AllAsync();

            return View(model);
        }
    }
}
