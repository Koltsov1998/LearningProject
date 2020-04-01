using LearningProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VkApi;
using VkApi.Messages;

namespace LearningProject.Services
{
    public class MemeParserService
    {
        private readonly ITextDetecter textDetecter;
        private readonly ProgressProcessStorage progressProcessStorage;
        private readonly ApiAccessProvider _apiAccessProvider;
        private readonly IServiceProvider _serviceProvider;

        public MemeParserService(ITextDetecter textDetecter,
            ProgressProcessStorage progressProcessStorage,
            ApiAccessProvider apiAccessProvider,
            IServiceProvider serviceProvider)
        {
            this.textDetecter = textDetecter;
            this.progressProcessStorage = progressProcessStorage;
            _apiAccessProvider = apiAccessProvider;
            _serviceProvider = serviceProvider;
        }

        public async Task<ImmutableArray<ParsedMeme>> ParsePhotos(GetPhotosInfos photos, int pubId)
        {
            List<ParsedMeme> result = new List<ParsedMeme>();

            progressProcessStorage.Progresses.Add(pubId, new Progress(photos.Response.Items.Length));

            foreach (var item in photos.Response.Items)
            {
                var photo = item.Sizes.Single(s => s.Type == "x");
                var text = await textDetecter.DetectText(photo.Url);
                ParsedMeme parsedMeme = new ParsedMeme
                {
                    Url = photo.Url,
                    Text = text,
                    VkPublicId = pubId
                };
                result.Add(parsedMeme);

                progressProcessStorage.Progresses[pubId].Done += 1;
                Console.WriteLine(
                    $"Processing memes {progressProcessStorage.Progresses[pubId].Done} / {photos.Response.Count}");
            }


            return result.ToImmutableArray();
        }

        public void StartParsingPhotosFromPublic(int publicId)
        {
            Task.Run(() =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _memeParserDataService = scope.ServiceProvider.GetService<MemeParserDataService>();

                    var pub = _memeParserDataService.GetVkPublicById(publicId);

                    var photoAlbum = _apiAccessProvider.GetPhotoAlbum(pub.VkId).GetAwaiter().GetResult();

                    var parsedMemes = ParsePhotos(photoAlbum, publicId).GetAwaiter().GetResult();

                    _memeParserDataService.AddMemes(parsedMemes);
                }
            });
        }
    }
}
