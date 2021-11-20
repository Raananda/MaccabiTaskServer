using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerTemplateSlim.Model
{
    public class VideoCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
