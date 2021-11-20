using Microsoft.AspNetCore.Identity;
using ServerTemplateSlim.Data;
using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using ServerTemplateSlim.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace ServerTemplateSlim.BLL
{
    public class VideoLinksService : IVideoLinksService
    {
        private readonly UserManager<MaccabiUser> _userManager;
        private readonly MaccabiContext _maccabiContext;

        public VideoLinksService(UserManager<MaccabiUser> userManager, MaccabiContext maccabiContext)
        {
            _userManager = userManager;
            _maccabiContext = maccabiContext;

        }


        public async Task<bool> AddVideo(VideoLinkDTO videoLinkDTO, string email)
        {

            // Get the user
            var user = await _userManager.FindByNameAsync(email);

            user.VideoLinkList = new List<VideoLink>();

            // Get the selected category
            var VideosCategory = (from vc in _maccabiContext.VideoCategories
                                  where vc.Name == videoLinkDTO.Category.Name
                                  select vc).SingleOrDefault();

            // Add new video link with its category
            user.VideoLinkList.Add(new VideoLink
            {
                Link = videoLinkDTO.Link,
                Category = VideosCategory
            });

            // Update database
            await _maccabiContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<VideoLink>> GetAllVideos(string email)
        {
            var Record = await (from mu in _maccabiContext.MaccabiUsers.Include(maccabiUser => maccabiUser.VideoLinkList).ThenInclude(VideoLink => VideoLink.Category)
                                where mu.Email == email
                                select mu).FirstOrDefaultAsync();

            return Record.VideoLinkList;
        }

        public async Task<bool> RemoveVideo(Guid videoLinkID)
        {
            var Record = await (from vl in _maccabiContext.VideoLinks
                                where vl.ID == videoLinkID
                                select vl).FirstOrDefaultAsync();

            if (Record != null)
            {
                _maccabiContext.Remove(Record);
                await _maccabiContext.SaveChangesAsync();
                return true;

            }
            return false;

        }

        public async Task<bool> UpdateVideo(VideoLink videoLink)
        {
            var Record = await (from vl in _maccabiContext.VideoLinks
                                where vl.ID == videoLink.ID
                                select vl).FirstOrDefaultAsync();

            if (Record != null)
            {
                Record.Link = videoLink.Link;
                Record.Category = videoLink.Category;
                await _maccabiContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
