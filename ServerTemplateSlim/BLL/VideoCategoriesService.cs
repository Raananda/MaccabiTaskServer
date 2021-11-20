using ServerTemplateSlim.Data;
using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using System.Threading.Tasks;

namespace ServerTemplateSlim.BLL
{
    public class VideoCategoriesService : IVideoCategoriesService
    {
        private readonly MaccabiContext _maccabiContext;

        public VideoCategoriesService(MaccabiContext maccabiContext)
        {
            _maccabiContext = maccabiContext;
        }
        public async Task<bool> AddCategory(VideoCategoryDTO videoCategoryDTO)
        {
            _maccabiContext.VideoCategories.Add(new Model.VideoCategory
            {
                Name = videoCategoryDTO.Name
            });

           await _maccabiContext.SaveChangesAsync();

            return true;
        }
    }
}
