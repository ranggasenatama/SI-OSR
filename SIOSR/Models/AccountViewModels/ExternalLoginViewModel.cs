using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
