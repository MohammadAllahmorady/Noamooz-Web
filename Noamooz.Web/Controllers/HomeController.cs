using Microsoft.AspNetCore.Mvc;
using Noamooz.Web.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Noamooz.Core.Models.ViewModel;

namespace Noamooz.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser>  signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            try
            {
                if (user!=null)
                {
                    var signinResult = await _signInManager.PasswordSignInAsync(user.UserName,model.Password,false,false);
                    if (signinResult.Succeeded)
                    {
                        return RedirectToAction("List", "Product");
                    }
                    else
                    {
                        TempData["Message"] = "ورود ناموفق بود";
                        return View();
                    }
                }
                TempData["Message"] = "ورود ناموفق بود";
                return View();
            }
            catch (Exception)
            {
                TempData["Message"] = "ورود ناموفق بود";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var userInfo = new IdentityUser
            {
                UserName = model.UserName,
                Email = string.Empty
            };

            var userResult =await _userManager.CreateAsync(userInfo, model.Password);
            if (userResult.Succeeded)
            {
                var signinResult = await _signInManager.PasswordSignInAsync(userInfo, model.Password, false, false);
                if (signinResult.Succeeded)
                {
                    return RedirectToAction("list","Product");
                }
            }
            TempData["Message"] = "ثبتنام ناموفق بود";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
