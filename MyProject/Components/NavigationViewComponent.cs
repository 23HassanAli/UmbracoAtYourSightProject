using Microsoft.AspNetCore.Mvc;

using static System.Net.Mime.MediaTypeNames;

namespace MyProject.Components
{

    [ViewComponent(Name ="Navigation")]
    public class NavigationViewComponent : ViewComponent
    {
        //to show this view component in the header you need @await Component.InvokeAsync("Navigaiton)
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
