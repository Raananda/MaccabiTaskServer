using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using ServerTemplateSlim.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoLinksController : ControllerBase
    {
        private readonly IVideoLinksService _videosService;
        private readonly UserManager<MaccabiUser> _userManager;

        public VideoLinksController(IVideoLinksService videosService, UserManager<MaccabiUser> userManager)
        {
            _videosService = videosService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddVideo(VideoLinkDTO videoLinkDTO)
        {
           // var Email = User.Claims.First(c => c.Type == "UserEmail").Value;
            var Response = await _videosService.AddVideo(videoLinkDTO, "aaa@sss.com");
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
        public async Task<IActionResult> GetAllVideos()
        {
           // var Email = User.Claims.First(c => c.Type == "UserEmail").Value;
            var Response = await _videosService.GetAllVideos("aaa@sss.com");

            return Ok(Response);       
        }

        [HttpPatch]
        public async Task<IActionResult> GetAllVideos(VideoLink videoLink)
        {
            var Response = await _videosService.UpdateVideo(videoLink);
            if (Response)
            {
                return StatusCode(201);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> GetAllVideos(Guid videoLinkID)
        {
            var Response = await _videosService.RemoveVideo(videoLinkID);
            if (Response)
            {
                return StatusCode(201);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
