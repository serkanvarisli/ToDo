﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public IActionResult Index()
        {
            string username = User.Identity.Name;
            var UserId = _context.Users
                .Where(l => l.UserMail == username)
                .Select(l=>l.UserId)
                .SingleOrDefault();
            ViewBag.Username = username;
            ViewBag.UserId = UserId;
            

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add(List list)
        {
            _context.Lists.Add(list);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Delete()
        {
            return View();
        }

    }
}