using ServerTemplateSlim.Model;

namespace ServerTemplateSlim.Infra.DTO
{
    public class VideoLinkDTO
    {
        public string Link { get; set; }
        public VideoCategoryDTO Category { get; set; }
    }
}
