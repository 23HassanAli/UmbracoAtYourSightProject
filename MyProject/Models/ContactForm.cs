using SixLabors.ImageSharp.Web.Commands;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class ContactForm
    {
        [Required]
        [Display(Name = "Full Name:")]
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Message { get; set; }
        public string? Token { get; set; }

    }
}
