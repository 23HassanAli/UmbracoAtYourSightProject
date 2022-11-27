using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace MyProject.Components.Navigation
{
    public class NavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new NavigationViewModel()
            {
                Temperature = "20"

            });
        }
    }
}
