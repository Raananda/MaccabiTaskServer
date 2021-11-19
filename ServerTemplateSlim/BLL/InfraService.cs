using ServerTemplateSlim.Infra.Interfaces.BLL;
using ServerTemplateSlim.Infra.Interfaces.DAL.DbContext;
using ServerTemplateSlim.Infra.Interfaces.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerTemplateSlim.BLL
{
    public class InfraService : IInfraService
    {
        private readonly IInfraConext _infraContext;

        public InfraService(IInfraConext infraContext)
        {
            _infraContext = infraContext;
        }

        public async Task<List<AppInitResponseDTO>> GetInitDataAsync()
        {
            return await _infraContext.GetInitDataAsync(); 
        }

        public async Task PostDataAsync(AppRequestDTO appRequestDTO)
        {
            await _infraContext.PostDataAsync(appRequestDTO);
        }
    }
}
