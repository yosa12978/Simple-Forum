using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using simple_Forum.Models;
using simple_Forum.Services;

namespace simple_Forum.Controllers
{
    public class ForumController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IPostManager _postManager;
        private readonly IDiscussManager _discussManager;
        private readonly IUserService _userService;
        public ForumController
            (
            ICategoryManager categoryManager, 
            IPostManager postManager, 
            IDiscussManager discussManager,
            IUserService userService
            )
        {
            _postManager = postManager;
            _categoryManager = categoryManager;
            _discussManager = discussManager;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(string? search)
        {
            var result = _postManager.GetAll();
            if (search != null)
            {
                result = _postManager.SearchPost(search);
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Category(long id, string? search)
        {
            if (!_categoryManager.IsCategoryExist(id))
                return NotFound();
            ViewBag.Category = _categoryManager.GetOne(id);
            var result = _categoryManager.GetCategoryPosts(id);
            if(search != null)
            {
                result = _postManager.SearchPostByCategory(search, id);
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Detail(long? id)
        {
            if (id == null)
                return NotFound();
            long postid = (long)id;
            Post post = _postManager.GetDetail(postid);
            if (post == null)
                return NotFound();
            ViewBag.Discussies = _discussManager.GetPostDiscussions(postid);
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(long? id, string text)
        {
            if (id == null)
                return NotFound();
            long postid = (long)id;
            if (!_postManager.IsPostExist(postid))
                return NotFound();
            _discussManager.CreateDiscuss(text, postid, HttpContext.User.Identity.Name);
            return Redirect($"/Forum/Detail/{id}");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(long? id)
        {
            if (id == null)
                return NotFound();
            if (!_categoryManager.IsCategoryExist((long)id))
                return NotFound();
            ViewBag.Category = _categoryManager.GetOne((long)id);
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(long? id, string title, string text)
        {
            if (id == null)
                return NotFound();
            if (!_categoryManager.IsCategoryExist((long)id))
                return NotFound();
            User author = _userService.GetUserByUsername(HttpContext.User.Identity.Name);
            Category category = _categoryManager.GetOne((long)id);
            if (title == null)
            {
                ViewBag.Category = _categoryManager.GetOne((long)id);
                ViewBag.Error = "you should enter the title";
                return View();
            }
            _postManager.CreatePost(title, text, category, author);
            ViewBag.Success = "theme created successfully";
            ViewBag.Category = _categoryManager.GetOne((long)id);
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
                return NotFound();
            var post = _postManager.GetDetail((long)id);
            if (post == null)
                return NotFound();
            if (post.Author.username != HttpContext.User.Identity.Name)
                return NotFound();
            _postManager.RemovePost(post.id);
            return Redirect($"/Account/?name={HttpContext.User.Identity.Name}");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null)
                return NotFound();
            Post det = _postManager.GetDetail((long)id); 
            if(HttpContext.User.Identity.Name != det.Author.username)
                return NotFound();
            ViewBag.Categories = _categoryManager.GetAllCategoryes();
            ViewBag.curr = det;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(long? id, string title, string text, long category)
        {
            if (id == null)
                return NotFound();
            Category newcate = _categoryManager.GetOne(category);
            bool editedpost = _postManager.EditPost((long)id, title, text, newcate, HttpContext.User.Identity.Name);
            if (!editedpost)
                return NotFound();
            return Redirect($"/Account/?name={HttpContext.User.Identity.Name}");
        }
    }
}