using System.ComponentModel.DataAnnotations;

namespace UserAuthExample.Models
{
    public class ForgotPassword
    {
        [Required]
        public string Username { get; set; }
    }
}
