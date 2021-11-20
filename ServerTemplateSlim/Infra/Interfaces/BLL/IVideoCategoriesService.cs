using ServerTemplateSlim.Infra.DTO;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Infra.Interfaces.BLL
{
    public interface IVideoCategoriesService
    {
        Task<bool> AddCategory(VideoCategoryDTO Name);

    }
}
