using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDo.Models;

namespace ToDo.Controllers
{
    [Authorize(AuthenticationSchemes = "UserAuthentication")]
    public class HomeController : Controller
    {
        MyDbContext _context;
        public HomeController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}