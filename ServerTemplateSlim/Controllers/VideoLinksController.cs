using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<IActionResult> AddVideoLink(VideoLinkDTO videoLinkDTO)
        {
            var Email = User.Claims.First(c => c.Type == "UserEmail").Value;
            var Response = await _videosService.AddVideo(videoLinkDTO, Email);
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
            var Email = User.Claims.First(c => c.Type == "UserEmail").Value;
            var Response = await _videosService.GetAllVideos(Email);

            return Ok(Response);       
        }

        [HttpPut]
        public async Task<IActionResult> PutVideoLink(VideoLinkPutDTO videoLinkPutDTO)
        {
            var Response = await _videosService.UpdateVideo(videoLinkPutDTO);
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
        public async Task<IActionResult> DeleteVideoLink(string id)
        {
            var Response = await _videosService.RemoveVideo(id);
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
