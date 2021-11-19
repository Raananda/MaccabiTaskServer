using Newtonsoft.Json;
using ServerTemplateSlim.Infra.DTO.JsonLocalStorage;
using ServerTemplateSlim.Infra.Interfaces.BLL;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ServerTemplateSlim.BLL
{
    public class JsonLocalFileService : IJsonLocalFileService
    {
        public async Task<List<UserDTO>> GetJsonData()
        {
            //Option 1
            // read file into a string and deserialize JSON to a type
            List<UserDTO> Users = JsonConvert.DeserializeObject<List<UserDTO>>(File.ReadAllText(@"C:\Users\troni\source\repos\ServerTemplateSlim\ServerTemplateSlim\BLL\JsonLocalStorage\users.json"));


            //Option 2
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\troni\source\repos\ServerTemplateSlim\ServerTemplateSlim\BLL\JsonLocalStorage\users.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<UserDTO> Users2 = (List<UserDTO>)serializer.Deserialize(file, typeof(List<UserDTO>));
                return Users2;
            }
        }
    }
}
