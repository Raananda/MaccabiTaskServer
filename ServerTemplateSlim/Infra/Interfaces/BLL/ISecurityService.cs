using Microsoft.AspNetCore.Identity;
using ServerTemplateSlim.Infra.DTO;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Infra.Interfaces.BLL
{
    public interface ISecurityService
    {
        Task<IdentityResult> RegisterUser(RegistrationDTO registrationDTO);
        string Login(LoginDTO loginDTO);
    }
}
