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
    }
}
