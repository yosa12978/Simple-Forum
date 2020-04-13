using Microsoft.EntityFrameworkCore;
using simple_Forum.Data;
using simple_Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_Forum.Services
{
    public interface ICategoryManager
    {
        List<Category> GetAllCategoryes();
        void AddCategory(string title);
        Category GetOne(long id);
        List<Post> GetCategoryPosts(long id);
        bool IsCategoryExist(long id);
    }
    public class CategoryManager : ICategoryManager
    {
        private readonly SFContext _context;
        public CategoryManager(SFContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategoryes()
        {
            return _context.Category
                .OrderBy(m => m.title)
                .ToList();
        }

        public List<Post> GetCategoryPosts(long id)
        {
            return _context.Post
                .Include(m => m.category)
                .Include(m => m.Author)
                .Where(m => m.category.id == id)
                .OrderByDescending(m => m.id)
                .ToList();
        }

        public Category GetOne(long id)
        {
            return _context.Category.Find(id);
        }

        public void AddCategory(string title)
        {
            Category cat = new Category { title = title };
            _context.Category.Add(cat);
            _context.SaveChanges();
        }

        public bool IsCategoryExist(long id)
        {
            if (id == null)
                return false;
            return _context.Category
                .Any(m => m.id == id);
        }
    }
}
