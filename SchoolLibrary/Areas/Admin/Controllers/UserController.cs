using Microsoft.AspNetCore.Mvc;
using SchoolLibrary.Core.Contracts;

namespace SchoolLibrary.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        public async Task<IActionResult> All()
        {
            var model = await userService.AllAsync();
            return View(model);
        }
    }
}
