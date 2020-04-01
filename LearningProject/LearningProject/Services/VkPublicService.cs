using System.Collections.Generic;
using System.Linq;
using LearningProject.API.Contracts;
using LearningProject.Models;
using Microsoft.EntityFrameworkCore;
using VkApi;
using System.Text.RegularExpressions;

namespace LearningProject.Services
{
    public class VkPublicService : IVkPublicService
    {
        private readonly ApiAccessProvider apiAccessProvider;
       
        private readonly DataContext _context;
        private readonly MemeParserDataService memeParser;

        public VkPublicService(DataContext context, MemeParserDataService memeParser)
        {
            _context = context;
            this.memeParser = memeParser;
            apiAccessProvider = new ApiAccessProvider();
        }

        public IEnumerable<VkPublicContract> GetAllVkPublics()
        {
            return _context.VkPublics
                .Include(p => p.Posts)
                .Select(p => new VkPublicContract
                {
                    Url = p.Url,
                    PostsParsed = p.Posts.Count(),
                    Id = p.Id,
                    Descritption = p.Descritption,
                    Name = p.Name,
                    Photo100 = p.Photo100,
                    Photo200 = p.Photo200,
                    Photo50 = p.Photo50 
                }).ToArray();
        }

        public void AddVkPublic(string url)
        {
            Regex regex = new Regex(@"vk\.com/(\S+)");
            if (!regex.IsMatch(url))
            {
                throw new System.Exception("Название паблика имеет неверный формат");
            }
            var match = regex.Match(url);
            var name = match.Groups[1].Value;

            var groupInfo = apiAccessProvider.GetGroupInfo(name).GetAwaiter().GetResult();
            
            _context.VkPublics.Add(new VkPublic
            {
                Url = url,
                VkId = groupInfo.Id, 
                Name = groupInfo.Name, 
                ScreenName = groupInfo.ScreenName, 
                IsClosed = groupInfo.IsClosed, 
                Type = groupInfo.Type, 
                IsAdmin = groupInfo.IsAdmin, 
                IsMember = groupInfo.IsMember, 
                IsAdvertiser = groupInfo.IsAdvertiser, 
                Descritption = groupInfo.Descritption, 
                Photo50 = groupInfo.Photo50, 
                Photo100 = groupInfo.Photo100, 
                Photo200 = groupInfo.Photo200, 
            });

            _context.SaveChanges();

            //memeParser.StartParsingPhotosFromPublic(groupInfo.Id).GetAwaiter().GetResult();
        }

        public void RemovePublic(int id)
        {
           var delPub = _context.VkPublics.Single(p => p.Id == id);

            _context.VkPublics.Remove(delPub);
            _context.SaveChanges();
        }
    }
}
