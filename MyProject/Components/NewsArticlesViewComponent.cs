using Microsoft.AspNetCore.Mvc;
using MyProject.Repository;

namespace MyProject.Components
{
    [ViewComponent(Name = "NewsArticles")]
    public class NewsArticlesViewComponent : ViewComponent
    {

       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            NewsApiRepository newsApiRepository = new NewsApiRepository();
            var newsArticles = await newsApiRepository.GetArticles();
            if (newsArticles == null)
                return View();

            return View(newsArticles);
        }
    }
}
