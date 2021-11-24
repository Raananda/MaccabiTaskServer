using System.ComponentModel.DataAnnotations;

namespace ServerTemplateSlim.Infra.DTO
{
    public class RegistrationDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
