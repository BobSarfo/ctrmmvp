using System.ComponentModel.DataAnnotations;

namespace ctrmmvp.DTOs.Auth
{
    public class LoginRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        
        public string? Company { get; set; }    
        
        public string? Branch { get; set; }
    }
}
