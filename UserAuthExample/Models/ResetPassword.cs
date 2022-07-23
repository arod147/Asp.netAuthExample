using System.ComponentModel.DataAnnotations;

namespace UserAuthExample.Models
{
    public class ResetPassword
    {
        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password is invlid please follow password rules")]
        public string Password { get; set; }
    }
}
