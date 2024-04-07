using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SchoolLibrary.Core.Constants.AdministratorConstants;

namespace SchoolLibrary.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
    }
}
