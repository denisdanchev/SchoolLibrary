using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SchoolLibrary.Core.Constants.RoleConstants;

namespace SchoolLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
    }
}
