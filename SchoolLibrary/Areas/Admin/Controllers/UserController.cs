using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Administrator.User;
using static SchoolLibrary.Core.Constants.AdministratorConstants;

namespace SchoolLibrary.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;
        public UserController(IUserService _userService, IMemoryCache _memoryCache)
        {
            userService = _userService;
            memoryCache = _memoryCache;
        }
        public async Task<IActionResult> All()
        {
            var model = memoryCache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);
            if (model == null || model.Any() == false)
            {
                model = await userService.AllAsync();

                var cacheOpions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                memoryCache.Set(UsersCacheKey, model, cacheOpions);
            }

            model = await userService.AllAsync();
            return View(model);
        }
    }
}
