using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerTemplateSlim.Model
{
    public class VideoLink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public string Link { get; set; }
        public VideoCategory Category { get; set; }
    }
}
