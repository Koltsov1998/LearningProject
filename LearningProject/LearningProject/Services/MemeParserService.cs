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
        private readonly AppSettings _appSettings;

        public MemeParserService(ITextDetecter textDetecter,
            ProgressProcessStorage progressProcessStorage,
            ApiAccessProvider apiAccessProvider,
            IServiceProvider serviceProvider,
            AppSettings appSettings)
        {
            this.textDetecter = textDetecter;
            this.progressProcessStorage = progressProcessStorage;
            _apiAccessProvider = apiAccessProvider;
            _serviceProvider = serviceProvider;
            _appSettings = appSettings;
        }

        public async Task<ImmutableArray<ParsedMeme>> ParsePhotos(PhotoAlbumInfo photos, int pubId)
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
            Task.Run(async () =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _memeParserDataService = scope.ServiceProvider.GetService<MemeParserDataService>();

                    var pub = _memeParserDataService.GetVkPublicById(publicId);

                    var photoAlbum = await _apiAccessProvider.GetPhotoAlbum(pub.VkId, _appSettings.ParsingDepth);

                    var parsedMemes = await ParsePhotos(photoAlbum, publicId);

                    _memeParserDataService.AddMemes(parsedMemes);
                }
            });
        }
    }
}
