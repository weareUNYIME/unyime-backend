using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace UnyimeWebApp.Controllers
{
    public class IndividualDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //applications, Favourites, Explore - Settings, HelpCentre, Refer Family&Friends, LogOut
        public IActionResult Applications()
        {
            return View();
        }

        public IActionResult Favourites()
        {
            return View();
        }

        public IActionResult Explore()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult HelpCentre()
        {
            return View();
        }

        public IActionResult Referral()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            // HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Home");
        }
    }
}
