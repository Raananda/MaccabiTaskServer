using ServerTemplateSlim.Model;
using System.ComponentModel.DataAnnotations;

namespace ServerTemplateSlim.Infra.DTO
{
    public class VideoLinkDTO
    {
        [Required]
        public string Link { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
