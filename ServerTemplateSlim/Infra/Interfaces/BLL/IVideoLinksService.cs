using ServerTemplateSlim.Infra.DTO;
using ServerTemplateSlim.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Infra.Interfaces.BLL
{
    public interface IVideoLinksService
    {
        Task<bool> AddVideo(VideoLinkDTO videoLinkDTO, string Email);
        Task<bool> RemoveVideo(Guid videoLinkID);
        Task<bool> UpdateVideo(VideoLink videoLink);
        Task<List<VideoLink>> GetAllVideos(string Email);
    }
}
