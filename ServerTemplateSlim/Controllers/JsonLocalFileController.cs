using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerTemplateSlim.Infra.DTO.JsonLocalStorage;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonLocalFileController : ControllerBase
    {
        private readonly ILogger<InfraController> _logger;
        private readonly IJsonLocalFileService _jsonLocalFileService;

        public JsonLocalFileController(ILogger<InfraController> logger, IJsonLocalFileService jsonLocalFileService)
        {
            _logger = logger;
            _jsonLocalFileService = jsonLocalFileService;
        }

        [HttpGet]
        [Route("get-json-data")]
        public async Task<ActionResult<List<UserDTO>>> GetInit()
        {
            return await _jsonLocalFileService.GetJsonData();
        }
    }
}
