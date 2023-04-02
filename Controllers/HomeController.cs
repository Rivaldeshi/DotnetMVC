using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestAplication.DAL;
using TestAplication.Models;
using TestAplication.Models.ViewModels;

namespace TestAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _userContext;

        public HomeController(ILogger<HomeController> logger, UserContext userContext)
        {
            _logger = logger;
            _userContext = userContext;
        }

        public IActionResult Index()
        {
            List<User> users = _userContext.Users.ToList();

            IndexViewModel view = new IndexViewModel
            {
                Users = users
            };
            return View(view);
        }

        public IActionResult CreateOrEdit(string id)
        {
            AddViewModel viewModel = new AddViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                User? user = _userContext.Users.Find(Guid.Parse(id));
                viewModel.User = user;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateOrEdit(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id != null && user.Id != default(Guid))
                {
                    User newuser = new User() { Id = user.Id };
                    _userContext.Users.Attach(newuser);
                    newuser.Name = user.Name;
                    newuser.SurName = user.SurName;
                }
                else
                {
                    _userContext.Users.Add(user);
                }

                _userContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult DeleteUser(string id)
        {
            User user = new User() { Id = Guid.Parse(id) };
            _userContext.Users.Attach(user);
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GetSimilarName(string name)
        {
            var suggestions = _userContext.Users
              .Where(u => u.Name.StartsWith(name))
              .Select(u => new { Name = u.Name })
              .ToList();

            return Json(suggestions);
        }


        public IActionResult Privacy()
        {
            return View();
        }


    }
}
