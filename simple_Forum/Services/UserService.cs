using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using simple_Forum.Data;
using simple_Forum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace simple_Forum.Services
{
    public interface IUserService
    {
        List<Post> GetUserPosts(string username);
        User GetUserByUsername(string username);
        bool IsUserExist(string username);
        void CreateUser(string username, string password, string passwordC);
        ClaimsPrincipal Authenticate(string username, string password);
        List<Post> SearchUserPosts(string username, string? search);
        void UpdateIcon(string username, IFormFile icon);
        bool IsTokenExist(string token);
    }
    public class UserService : IUserService
    {
        private readonly SFContext _context;
        private readonly IWebHostEnvironment _appEnvironment;
        public UserService(SFContext context,  IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public User GetUserByUsername(string username)
        {
            return _context.User.FirstOrDefault(m => m.username == username);
        }

        public bool IsUserExist(string username)
        {
            return _context.User.Any(m => m.username == username);
        }

        public bool isUserHashExist(string username, string hashed_password)
        {
            return _context.User
                .Any(m => m.username == username && m.password == hashed_password);
        }

        public List<Post> GetUserPosts(string username)
        {
            return _context.Post
                .Include(m => m.Author)
                .Where(m => m.Author.username == username)
                .OrderByDescending(m => m.id)
                .ToList();
        }

        public List<Post> SearchUserPosts(string username, string search)
        {
            return _context.Post
                .Include(m => m.Author)
                .Include(m => m.category)
                .Where(m => m.Author.username == username && m.title.Contains(search))
                .OrderByDescending(m => m.id)
                .ToList();
        }

        public ClaimsPrincipal Authenticate(string username, string password)
        {
            static string ComputeHash(string rawData)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }

            string hashed_password = ComputeHash(password);
            if (!isUserHashExist(username, hashed_password))
                return null;


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, Role.User)
            };
            var userIdentety = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentety);

            GetUserByUsername(username).IsLoggedNow = true;
            return principal;
        }

        public void CreateUser(string username, string password, string passwordC)
        {
            static string ComputeHash(string rawData)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            User newuser = new User
            {
                username = username,
                password = ComputeHash(password),
                token = ComputeHash(username + DateTime.UtcNow.ToString()),
                IsLoggedNow = false,
                Role = Role.User
            };
            _context.User.Add(newuser);
            _context.SaveChanges();
        }

        public List<User> AllUsers()
        {
            return _context.User
                .OrderByDescending(m => m.id)
                .ToList();
        }

        public bool IsTokenExist(string token)
        {
            return _context.User.Any(m => m.token == token);
        }

        public void UpdateIcon(string username, IFormFile icon)
        {
            User user = GetUserByUsername(username);
            string path = "/Icons/" + icon.FileName;
            icon.CopyTo(new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create));
            user.icon = path;
            _context.User.Update(user);
            _context.SaveChanges();
        }
    }
}
