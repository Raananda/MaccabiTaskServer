using System.ComponentModel.DataAnnotations;

namespace ServerTemplateSlim.Infra.DTO
{
    public class VideoCategoryDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
