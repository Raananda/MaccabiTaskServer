using ServerTemplateSlim.Data;
using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using ServerTemplateSlim.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            // If exists
            if (_maccabiContext.VideoCategories.Any(o => o.Name == videoCategoryDTO.Name)) return false;

            await _maccabiContext.VideoCategories.AddAsync(new Model.VideoCategory
            {
                Name = videoCategoryDTO.Name
            });

            await _maccabiContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<VideoCategory>> GetAllCategory()
        {

            var Result = (from vc in _maccabiContext.VideoCategories
                          select vc).ToList();

            return Result;
        }
    }
}
