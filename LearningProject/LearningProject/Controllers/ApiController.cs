using LearningProject.API.Contracts;
using LearningProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningProject.Controllers
{
    public class ApiController : Controller
    {
        private readonly IVkPublicService _vkPublicService;

        public ApiController(IVkPublicService vkPublicService)
        {
            _vkPublicService = vkPublicService;
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
        public IActionResult RemovePublic([FromBody] string publicUrl)
        {
            _vkPublicService.RemovePublic(publicUrl); 
            return Ok();
        }
    }
}
