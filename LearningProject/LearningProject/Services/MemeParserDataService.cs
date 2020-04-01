using LearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkApi;
using VkApi.Messages;

namespace LearningProject.Services
{
    public class MemeParserDataService 
    {
        private readonly DataContext _context;

        public MemeParserDataService(DataContext context)
        {
            _context = context;
        }

        public VkPublic GetVkPublicById(int publicId)
        {
            var pub = _context.VkPublics.Single(p => p.Id == publicId);
            return pub;
        }

        public void AddMemes(IEnumerable<ParsedMeme> parsedMemes)
        {
            _context.ParsedMemes.AddRange(parsedMemes);
            _context.SaveChanges();
        }

    }
}
