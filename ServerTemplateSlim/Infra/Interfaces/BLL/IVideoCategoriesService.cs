using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Infra.Interfaces.BLL
{
    public interface IVideoCategoriesService
    {
        Task<bool> AddCategory(VideoCategoryDTO Name);
        Task<List<VideoCategory>> GetAllCategory();

    }
}
