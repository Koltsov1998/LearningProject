using LearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkApi;

namespace LearningProject.Services
{
    public class MemeParserService:IMemeService
    {
        private readonly DataContext context;
        private readonly ApiAccessProvider apiAccessProvider;
        private readonly ITextDetecter textDetecter;

        public MemeParserService(DataContext context, ApiAccessProvider apiAccessProvider, ITextDetecter textDetecter)
        {
            this.context = context;
            this.apiAccessProvider = apiAccessProvider;
            this.textDetecter = textDetecter;

            // ParsePhotos();
        }

        public async Task ParsePhotosFromPublic(int publicId)
        {
            var photoAlbum = await apiAccessProvider.GetPhotoAlbum(publicId);
            foreach (var item in photoAlbum.Response.Items)
            {
                var photo = item.Sizes.Single(s => s.Type == "x");
                var text = textDetecter.DetectText(photo.Url);
                ParsedMeme parsedMeme = new ParsedMeme
                {
                    Url = photo.Url,
                    Text = text,
                    VkPublic = p
                };

                context.ParsedMemes.Add(parsedMeme);
            }

            context.SaveChanges();
        }

        private async void ParsePhotos()
        {
            var publics = context.VkPublics;

            foreach(var p in publics)
            {
                var photoAlbum = await apiAccessProvider.GetPhotoAlbum(p.VkId);
                foreach(var item in photoAlbum.Response.Items)
                {
                    var photo = item.Sizes.Single(s => s.Type == "x");
                    var text = textDetecter.DetectText(photo.Url);
                    ParsedMeme parsedMeme = new ParsedMeme
                    {
                        Url = photo.Url,
                        Text = text,
                        VkPublic = p
                    };
                    
                    context.ParsedMemes.Add(parsedMeme);
                }
                
            }
        }
    }
}
