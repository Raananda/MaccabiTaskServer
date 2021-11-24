using System;
using System.ComponentModel.DataAnnotations;

namespace ServerTemplateSlim.Infra.DTO
{
    public class VideoLinkPutDTO: VideoLinkDTO
    {
        [Required]
        public string ID { get; set; }
    }
}
