using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTemplateSlim.Infra.DTO.JsonLocalStorage
{
    public class UserDTO
    {
        public string id { get; set; }
        public string date { get; set; }
        public int age { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}
