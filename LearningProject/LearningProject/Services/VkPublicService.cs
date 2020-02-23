using System.Collections.Generic;
using System.Linq;
using LearningProject.API.Contracts;
using LearningProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningProject.Services
{
    public class VkPublicService : IVkPublicService
    {
        private readonly DataContext _context;

        public VkPublicService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<VkPublicContract> GetAllVkPublics()
        {
            return _context.VkPublics
                .Include(p => p.Posts)
                .Select(p => new VkPublicContract
                {
                    Uri = p.Uri,
                    PostsParsed = p.Posts.Count()
                }).ToArray();
        }

        public void AddVkPublic(string url)
        {
            _context.VkPublics.Add(new VkPublic
            {
                Uri = url,
            });

            _context.SaveChanges();
        }

        public void RemovePublic(string url)
        {
           var delPub = _context.VkPublics.Single(p => p.Uri == url);

            _context.VkPublics.Remove(delPub);
            _context.SaveChanges();
        }
    }
}
