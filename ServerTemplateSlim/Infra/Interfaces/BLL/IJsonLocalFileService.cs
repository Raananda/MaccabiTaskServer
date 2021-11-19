using ServerTemplateSlim.Infra.DTO.JsonLocalStorage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Infra.Interfaces.BLL
{
    public interface IJsonLocalFileService
    {
        Task<List<UserDTO>> GetJsonData();
    }
}
