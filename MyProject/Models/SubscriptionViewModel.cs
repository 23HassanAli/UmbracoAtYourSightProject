using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class SubscriptionViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
