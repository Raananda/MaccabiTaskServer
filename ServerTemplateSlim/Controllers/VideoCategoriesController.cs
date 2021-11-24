using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VideoCategoriesController : ControllerBase
    {
        private readonly IVideoCategoriesService _videoCategoriesService;

        public VideoCategoriesController(IVideoCategoriesService videoCategoriesService)
        {
            _videoCategoriesService = videoCategoriesService;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(VideoCategoryDTO videoCategoryDTO)
        {
            var Response = await _videoCategoriesService.AddCategory(videoCategoryDTO);

            if (Response)
            {
                return StatusCode(201);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var Response = await _videoCategoriesService.GetAllCategory();

            return Ok(Response);
        }
    }
}
