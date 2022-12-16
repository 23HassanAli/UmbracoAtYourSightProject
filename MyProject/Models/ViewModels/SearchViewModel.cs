using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Umbraco.Cms.Core.Composing;

namespace MyProject.Models.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Search Term")]
        [Required(ErrorMessage = "You must enter a search term")]  
        public string? Query { get; set; }
        [Display(Name = "Category")]
        public string? Category { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        //[Display(Name = "Page Number")]
        public string? Page { get; set; }
    }
}
