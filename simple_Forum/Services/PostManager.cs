using Microsoft.EntityFrameworkCore;
using simple_Forum.Data;
using simple_Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_Forum.Services
{
    public interface IPostManager
    {
        List<Post> GetAll();
        bool IsPostExist(long? id);
        Post GetDetail(long id);
        List<Post> TakeSome(int count);
        void CreatePost(string title, string text, Category category, User Author);
        List<Post> SearchPostByCategory(string search, long categoryid);
        List<Post> SearchPost(string search);
        void RemovePost(long id);
        bool EditPost(long id, string title, string text, Category category, string username);
    }
    public class PostManager : IPostManager
    {
        private readonly SFContext _context;
        public PostManager(SFContext context)
        {
            _context = context;
        }

        public List<Post> GetAll()
        {
            return _context.Post
                .Include(m => m.Author)
                .Include(m => m.category)
                .OrderByDescending(m => m.id)
                .ToList();
        }

        public List<Post> TakeSome(int count)
        {
            return _context.Post
                .Include(m => m.Author)
                .Include(m => m.category)
                .OrderByDescending(m => m.id)
                .Take(count)
                .ToList();
        }

        public bool IsPostExist(long? id)
        {
            if (id == null)
                return false;
            return _context.Post
                .Any(m => m.id == id);
        }

        public Post GetDetail(long id)
        {
            return _context.Post
                .Include(m => m.Author)
                .Include(m => m.category)
                .FirstOrDefault(m => m.id == id);
        }

        public List<Post> SearchPost(string search)
        {
            return _context.Post
                .Include(m => m.Author)
                .Include(m => m.category)
                .OrderByDescending(m => m.id)
                .Where(m => m.title.Contains(search))
                .ToList();
        }

        public List<Post> SearchPostByCategory(string search, long categoryid)
        {
            return _context.Post
                .Include(m => m.Author)
                .Include(m => m.category)
                .OrderByDescending(m => m.id)
                .Where(m => m.title.Contains(search) && m.category.id == categoryid)
                .ToList();
        }

        public void RemovePost(long id)
        {
            Post post = _context.Post.FirstOrDefault(m => m.id == id);
            _context.Post.Remove(post);
            _context.SaveChanges();
        }

        public bool EditPost(long id, string title, string text, Category category, string username)
        {
            Post edpost = _context.Post.Include(m => m.Author).FirstOrDefault(m => m.id == id);
            if (edpost.Author.username != username)
                return false;
            edpost.title = title;
            edpost.text = text;
            edpost.category = category;
            _context.Post.Update(edpost);
            _context.SaveChanges();
            return true;
        }

        public void CreatePost(string title, string text, Category category, User author)
        {
            Post newpost = new Post
            {
                title = title,
                text = text,
                category = category,
                Author = author
            };
            _context.Post.Add(newpost);
            _context.SaveChanges();
        }
    }
}
