using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using ServerTemplateSlim.Infra.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfraController : ControllerBase
    {
        private readonly ILogger<InfraController> _logger;
        private readonly IInfraService _infraService;

        public InfraController(ILogger<InfraController> logger, IInfraService infraService)
        {
            _logger = logger;
            _infraService = infraService;
        }

        [HttpGet]
        [Route("get-init")]
        public async Task<ActionResult<List<AppInitResponseDTO>>> GetInit()
        {
            return await _infraService.GetInitDataAsync();
        }

        [HttpPost]
        [Route("post-init")]
        public async Task<ActionResult<AppRequestDTO>> PostData(AppRequestDTO appRequestDTO)
        {
            await _infraService.PostDataAsync(appRequestDTO);

            return Ok(appRequestDTO);
        }

    }
}
