using Microsoft.AspNetCore.Mvc;

using static System.Net.Mime.MediaTypeNames;

namespace MyProject.Components
{
    [ViewComponent(Name ="Navigation")]
    public class NavigationViewComponent : ViewComponent
    {
        public async Task<ViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
