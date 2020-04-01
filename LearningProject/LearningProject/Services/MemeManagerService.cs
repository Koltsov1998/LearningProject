using LearningProject.API.Contracts;
using LearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Services
{
    public class MemeManagerService : IMemeManagerService
    {
        private readonly DataContext context;

        public MemeManagerService(DataContext context)
        {
            this.context = context;
        }
        public IEnumerable<ParsedMemeContract> GetParsedMemes(int publicId)
        {
            var memes = context.ParsedMemes
                .Where(m => m.VkPublicId == publicId)
                .Select(m => new ParsedMemeContract
                {
                    Id = m.Id,
                    Text = m.Text,
                    Url = m.Url
                });

            return memes;
        }
    }
}
