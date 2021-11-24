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
                                  where vc.Name == videoLinkDTO.Category
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

        public async Task<bool> RemoveVideo(string videoLinkID)
        {
            var Record = await (from vl in _maccabiContext.VideoLinks
                                where vl.ID == Guid.Parse(videoLinkID)
                                select vl).FirstOrDefaultAsync();

            if (Record != null)
            {
                _maccabiContext.Remove(Record);
                await _maccabiContext.SaveChangesAsync();
                return true;

            }
            return false;

        }

        public async Task<bool> UpdateVideo(VideoLinkPutDTO videoLinkPutDTO)
        {
            // Get the video link
            var Record = await (from vl in _maccabiContext.VideoLinks.Include(VideoLink => VideoLink.Category)
                                where vl.ID == Guid.Parse(videoLinkPutDTO.ID)
                                select vl).FirstOrDefaultAsync();

            // Get the category with Guid
            var Category = await (from vc in _maccabiContext.VideoCategories
                                  where vc.Name == videoLinkPutDTO.Category
                                  select vc).FirstOrDefaultAsync();

            if (Record != null)
            {
                Record.Link = videoLinkPutDTO.Link;
                Record.Category = Category;
                await _maccabiContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
