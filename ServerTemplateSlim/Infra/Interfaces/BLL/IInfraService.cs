using ServerTemplateSlim.Infra.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Infra.Interfaces.BLL
{
    public interface IInfraService
    {
        Task<List<AppInitResponseDTO>> GetInitDataAsync();
        Task PostDataAsync(AppRequestDTO appRequestDTO);
    }
}
