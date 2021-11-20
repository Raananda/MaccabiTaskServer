using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using ServerTemplateSlim.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServerTemplateSlim.BLL
{
    public class SecurityService : ISecurityService
    {
        private readonly UserManager<MaccabiUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public SecurityService
            (
            UserManager<MaccabiUser> userManager,
            IOptions<ApplicationSettings> appSettings
            )
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
            
        }

        public string Login(LoginDTO loginDTO)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                  {
                        new Claim("UserEmail", loginDTO.Email)
                  }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public async Task<IdentityResult> RegisterUser(RegistrationDTO registrationDTO)
        {
            // Can be replaced with automapper
            var user = new MaccabiUser();
            user.Email = registrationDTO.Email;
            user.PasswordHash = registrationDTO.Password;
            user.FirstName = registrationDTO.FirstName;
            user.LastName = registrationDTO.LastName;
            user.UserName = registrationDTO.Email;

            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            return result;
        }
    }
}
