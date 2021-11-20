using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            return Ok(Response);
        }
    }
}
