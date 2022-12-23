using Microsoft.AspNetCore.Mvc;

namespace MyProject.Components
{
    [ViewComponent(Name = "FeaturedStories")]
    public class FeaturedStoriesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IViewComponentResult> Invoke()
        //{
        //    ViewBag.ShowMoreArtikels = true;
        //    return View();
        //}
    }
}
