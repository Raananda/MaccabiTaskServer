using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Model
{
    public class MaccabiUser : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GuidId { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string LastName { get; set; }

        public List<VideoLink> VideoLinkList { get; set; }


    }
}
