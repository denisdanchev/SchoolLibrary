using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolLibrary.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        [Authorize(Roles = "Administrator")]
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> ForReview() 
        {
            return View();
        }
    }
}
