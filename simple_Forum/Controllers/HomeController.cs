using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simple_Forum.Models;
using simple_Forum.Services;

namespace simple_Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryManager _categoryManager;
        private readonly IPostManager _postManager;

        public HomeController(ILogger<HomeController> logger, ICategoryManager categoryManager, IPostManager postManager)
        {
            _logger = logger;
            _postManager = postManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _categoryManager.GetAllCategoryes();
            ViewBag.Posts = _postManager.TakeSome(5);
            return View();
        }

        public IActionResult Rules()
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
