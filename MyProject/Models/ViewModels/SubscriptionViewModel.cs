using System.ComponentModel.DataAnnotations;

namespace MyProject.Models.ViewModels
{
    public class SubscriptionViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
