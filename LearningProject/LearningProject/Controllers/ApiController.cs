using LearningProject.API.Contracts;
using LearningProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningProject.Controllers
{
    public class ApiController : Controller
    {
        private readonly IVkPublicService _vkPublicService;
        private readonly MemeParserService _memeParserService;
        private readonly IMemeManagerService _memeManagerService;
        private readonly ProgressProcessStorage _progressProcessStorage;

        public ApiController(IVkPublicService vkPublicService, MemeParserService memeParserService, 
            IMemeManagerService memeManagerService, ProgressProcessStorage progressProcessStorage)
        {
            _vkPublicService = vkPublicService;
            _memeParserService = memeParserService;
            _memeManagerService = memeManagerService;
            _progressProcessStorage = progressProcessStorage;
        }

        [HttpGet]
        [Route("~/api/publics")]
        [ProducesResponseType(typeof(VkPublicContract[]), 200)]
        public IActionResult GetVkPublics()
        {
            var publics = _vkPublicService.GetAllVkPublics();
            return Ok(publics);
        }

        [HttpPost]
        [Route("~/api/publics")]
        public IActionResult AddVkPublic([FromQuery] string PublicUrl)
        {
            _vkPublicService.AddVkPublic(PublicUrl);
            return Ok();
        }

        [HttpDelete]
        [Route("~/api/publics")]
        public IActionResult RemovePublic([FromBody] int id)
        {
            _vkPublicService.RemovePublic(id); 
            return Ok();
        }
        
        [HttpPost]
        [Route("~/api/memes/startparsing")]
        public  IActionResult StartPhotosParsing([FromBody] int publicId)
        {
            _memeParserService.StartParsingPhotosFromPublic(publicId);
            return Ok();
        }

        [HttpPost]
        [Route("~/api/memes/callformemes")]
        [ProducesResponseType(typeof(ParsedMemeContract[]), 200)]
        public IActionResult CallForMemes([FromBody] int publicId)
        {
            var memes = _memeManagerService.GetParsedMemes(publicId);
            return Ok(memes);
        }

        [HttpGet]
        [Route("~/api/memes/{publicId}/progress")]
        [ProducesResponseType(typeof(Progress), 200)]
        public IActionResult GetProgress(int publicId)
        {
            if(_progressProcessStorage.Progresses.ContainsKey(publicId))
            {
                var progress = _progressProcessStorage.Progresses[publicId];
                return Ok(progress);
            }
            else
            {
                return Ok(new Progress(0)
                {
                    Done = 0
                });
            }
        }
    }
}
