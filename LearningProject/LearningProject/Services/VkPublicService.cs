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
            return _context.VkPosts
                .Include(p => p.VkPublic)
                .GroupBy(p => p.VkPublic)
                .Select(g => new VkPublicContract
                {
                    Uri = g.Key.Uri,
                    PostsParsed = g.Count()
                });
        }
    }
}
