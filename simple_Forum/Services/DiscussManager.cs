using Microsoft.EntityFrameworkCore;
using simple_Forum.Data;
using simple_Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_Forum.Services
{
    public interface IDiscussManager
    {
        List<Discuss> GetPostDiscussions(long postid);
        void CreateDiscuss(string text, long postId, string username);
        List<Discuss> AllDiscuss();
    }
    public class DiscussManager : IDiscussManager
    {
        private readonly SFContext _context;

        public DiscussManager(SFContext context)
        {
            _context = context;
        }

        public List<Discuss> GetPostDiscussions(long postid)
        {
            return _context.Discuss
                .Include(m => m.Author)
                .Where(m => m.postIdnum == postid)
                .ToList();
        }

        public void CreateDiscuss(string text, long postId, string username)
        {
            Discuss newdiscuss = new Discuss
            {
                text = text,
                postIdnum = postId,
                Author = _context.User.FirstOrDefault(m => m.username == username)
            };
            _context.Discuss.Add(newdiscuss);
            _context.SaveChanges();
        }

        public List<Discuss> AllDiscuss()
        {
            return _context.Discuss
                .Include(m => m.Author)
                .OrderByDescending(m => m.id)
                .ToList();
        }

        public void RemoveDiscuss(long id)
        {
            Discuss deldata = _context.Discuss.FirstOrDefault(m => m.id == id);
            _context.Discuss.Remove(deldata);
            _context.SaveChanges();
        }

        public void EditDiscuss(long id, string text)
        {
            Discuss discuss = _context.Discuss.FirstOrDefault(m => m.id == id);
            discuss.text = text;
            _context.Discuss.Update(discuss);
            _context.SaveChanges();
        }
    }
}
