using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolLibrary.Infrastructure.Common;
using SchoolLibrary.Infrastructure.Data;

namespace SchoolLibrary.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Create(IdentityRole role)
        {
            if (!roleManager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
