using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class LoginController : Controller
    {
        MyDbContext _context;

        public LoginController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User model)
        {
            var user = _context.Users.FirstOrDefault(c => c.UserMail == model.UserMail && c.UserPassword == model.UserPassword);
            if (user != null)
            {
                await HttpContext.SignOutAsync("UserAuthentication");

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.UserMail));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("UserAuthentication", principal, new AuthenticationProperties() { IsPersistent = false });
                Response.Cookies.Append("UserMail", model.UserMail);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı";

            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }

}
