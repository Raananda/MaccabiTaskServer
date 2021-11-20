using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using ServerTemplateSlim.Model;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerTemplateSlim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        private readonly UserManager<MaccabiUser> _userManager;
        private readonly ISecurityService _securityService;

        public SecurityController(UserManager<MaccabiUser> userManager, ISecurityService securityService)
        {
            _userManager = userManager;
            _securityService = securityService;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser(RegistrationDTO registrationDTO)
        {
            if (registrationDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _securityService.RegisterUser(registrationDTO);

            if (!result.Succeeded)
            {
                var errors = (from error in result.Errors
                              select error.Description).ToList();

                return BadRequest(errors);
            }
            return StatusCode(201);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {

            var user = await _userManager.FindByNameAsync(loginDTO.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                var token = _securityService.Login(loginDTO);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Email or password is incorrect." });
        }


    }
}
