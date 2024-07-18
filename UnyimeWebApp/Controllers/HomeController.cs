using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Security.Claims;
using UnyimeWebApp.Models;
using Azure.Identity;

namespace IndexWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnyimeDbContext _dbContext;
        private readonly IPasswordHasher<Individual> _individualPasswordHasher;
        private readonly IPasswordHasher<Entity> _entityPasswordHasher;

        public HomeController(ILogger<HomeController> logger, UnyimeDbContext dbContext, IPasswordHasher<Individual> individualPasswordHasher, IPasswordHasher<Entity> entityPasswordHasher)
        {
            _logger = logger;
            _dbContext = dbContext;
            _individualPasswordHasher = individualPasswordHasher;
            _entityPasswordHasher = entityPasswordHasher;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult SignUpIndividual()
        {
            return View();
        }

        //POST
        //Add up form details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddIndividual(Individual individualDetails)
        {
            if (ModelState.IsValid)
            {
                individualDetails.IndividualPasswordHash = _individualPasswordHasher.HashPassword(individualDetails, individualDetails.IndividualPasswordHash);

                _dbContext.Individuals.Add(individualDetails);
                _dbContext.SaveChanges();
                return RedirectToAction("LogIn");
            }
            else
            {
                TempData["error"] = "An eror occured. Please try again!";
                return RedirectToAction("SignUpIndividual");
            }
        }

        //GET
        public IActionResult SignUpEntity()
        {
            return View();
        }

        //POST
        //Add up form details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEntity(Entity entityDetails)
        {
            if (ModelState.IsValid)
            {
                entityDetails.EntityPasswordHash = _entityPasswordHasher.HashPassword(entityDetails, entityDetails.EntityPasswordHash);

                _dbContext.Entities.Add(entityDetails);
                _dbContext.SaveChanges();
                return RedirectToAction("LogIn");
            }
            else
            {
                TempData["error"] = "An eror occured. Please try again!";
                return RedirectToAction("SignUpEntity");
            }
        }

        //GET
        public IActionResult IndividualLogIn()
        {
            return View();
        }

        //POST
        public IActionResult AuthenticateIndividual(Individual IndividualDetails)
        {
            var loginIndividual = _dbContext.Individuals.Where(uD => uD.IndividualUserName == IndividualDetails.IndividualUserName).FirstOrDefault();
            if (loginIndividual != null)
            {
                bool getIndividualDetails = GetIndividualDetails(IndividualDetails, loginIndividual.IndividualPasswordHash, IndividualDetails.IndividualPasswordHash);
                if (getIndividualDetails)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, IndividualDetails.IndividualUserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                    {
                        IsPersistent = false
                    });

                    //TempData["username"] = userDetails.UserName;
                    HttpContext.Session.SetString("individualFullName", IndividualDetails.IndividualUserName);

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Username or Password incorrect!";
                    return RedirectToAction("IndividualLogIn");
                }
            }
            else
            {
                TempData["error"] = "Username or Password incorrect!";
                return RedirectToAction("IndividualLogIn");
            }
        }

        public bool GetIndividualDetails(Individual IndividualDetails, string hashedPassword, string password)
        {
            var user = _dbContext.Individuals.SingleOrDefault(u => u.IndividualUserName == IndividualDetails.IndividualUserName);
            var checkHashedPassword = _individualPasswordHasher.VerifyHashedPassword(IndividualDetails, hashedPassword, password);
            if (checkHashedPassword == PasswordVerificationResult.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //About Us, Take Action, Explore
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult TakeAction()
        {
            return View();
        }

        public IActionResult Explore()
        {
            return View();
        }

        //GET
        public IActionResult EntityLogIn()
        {
            return View();
        }

        //POST
        public IActionResult AuthenticateEntity(Entity EntityDetails)
        {
            var loginIndividual = _dbContext.Individuals.Where(uD => uD.IndividualUserName == EntityDetails.EntityUserName).FirstOrDefault();
            if (loginIndividual != null)
            {
                bool getIndividualDetails = GetEntityDetails(EntityDetails, loginIndividual.IndividualPasswordHash, EntityDetails.EntityPasswordHash);
                if (getIndividualDetails)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, EntityDetails.EntityUserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                    {
                        IsPersistent = false
                    });

                    //TempData["username"] = userDetails.UserName;
                    HttpContext.Session.SetString("individualFullName", EntityDetails.EntityUserName);

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Username or Password incorrect!";
                    return RedirectToAction("IndividualLogIn");
                }
            }
            else
            {
                TempData["error"] = "Username or Password incorrect!";
                return RedirectToAction("IndividualLogIn");
            }
        }

        public bool GetEntityDetails(Entity EntityDetails, string hashedPassword, string password)
        {
            var user = _dbContext.Individuals.SingleOrDefault(u => u.IndividualUserName == EntityDetails.EntityUserName);
            var checkHashedPassword = _entityPasswordHasher.VerifyHashedPassword(EntityDetails, hashedPassword, password);
            if (checkHashedPassword == PasswordVerificationResult.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public IActionResult LogOut()
        {
            // HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login");
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
