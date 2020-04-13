using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple_Forum.Data;
using simple_Forum.Models;
using simple_Forum.Services;

namespace simple_Forum.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IPostManager _postManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IUserService _userServise;
        public APIController
            (
            IPostManager postManager,
            ICategoryManager categoryManager,
            IUserService userService
            )
        {
            _userServise = userService;
            _postManager = postManager;
            _categoryManager = categoryManager;
        }

        /// <summary>
        /// TODO: Complete the API Service
        /// </summary>

        [HttpGet]
        public IActionResult Index()
        {
            if (!_userServise.IsTokenExist(HttpContext.Request.Query["token"].ToString()))
                return Unauthorized();

            List<Post> result = _postManager.GetAll();
            return Ok(new { result = result });
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(long? id)
        {
            if (!_userServise.IsTokenExist(HttpContext.Request.Query["token"].ToString()))
                return Unauthorized();

            Post post = _postManager.GetDetail((long)id);
            return Ok(new { result = post });
        }

        [HttpGet("categories")]
        public IActionResult GetCategoryes()
        {
            if (!_userServise.IsTokenExist(HttpContext.Request.Query["token"].ToString()))
                return Unauthorized();

            List<Category> categories = _categoryManager.GetAllCategoryes();
            return Ok(new { result = categories });
        }
    }
}