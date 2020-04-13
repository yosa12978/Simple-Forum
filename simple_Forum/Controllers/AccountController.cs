using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simple_Forum.Data;
using simple_Forum.Models;
using simple_Forum.Services;

namespace simple_Forum.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(string? name, string? search)
        {
            if (name == null)
                name = HttpContext.User.Identity.Name;
            ViewBag.Posts = _userService.GetUserPosts(name);
            if(search != null)
            {
                ViewBag.Posts = _userService.SearchUserPosts(name, search);
            }
            if (!_userService.IsUserExist(name))
                return NotFound();
            ViewBag.UserData = _userService.GetUserByUsername(name);
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(IFormFile icon)
        {
            if (icon != null)
                _userService.UpdateIcon(HttpContext.User.Identity.Name, icon);
            return Redirect("/Account/");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("/Account/");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if(HttpContext.User.Identity.IsAuthenticated)
                return Redirect("/Account/");
            if (username == null || password == null) 
            {
                ViewBag.Error = "you should enter username and password";
                return View();
            }
            var user = _userService.Authenticate(username, password);
            if(user == null)
            {
                ViewBag.Error = "username or password is incorrect";
                return View();
            }
            await HttpContext.SignInAsync(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Signup()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("/Account/");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(string username, string password, string passwordC)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("/Account/");
            if (username == null || password == null)
            {
                ViewBag.Error = "you should enter username and pssword";
                return View();
            }
            if (!_userService.IsUserExist(username))
            {
                if (password != passwordC)
                {
                    ViewBag.Error = "passwords does not match";
                    return View();
                }
                _userService.CreateUser(username, password, passwordC);
                return Redirect("/Account/Login/"); 
            }
            ViewBag.Error = "user is already exist";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            _userService.GetUserByUsername(HttpContext.User.Identity.Name).IsLoggedNow = false;
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}