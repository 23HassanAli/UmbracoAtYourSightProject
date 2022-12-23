using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Models;
using MyProject.Repository;

namespace MyProject.Components
{
    [ViewComponent(Name = "NewsArticles")]
    public class NewsArticlesViewComponent : ViewComponent
    {

       
        public async Task<IViewComponentResult> InvokeAsync(List<NewsArticle> newNewsArticles)
        {
            ArticlesData articles = new ArticlesData();
            NewsApiRepository newsApiRepository = new NewsApiRepository(newNewsArticles);
            var newsArticles = await newsApiRepository.GetArticles(0, 5);
            //if (newNewsArticles != null)
            //newNewsArticles.Add(newNewsArticles);
            if (newsArticles == null)
                return View();

            return View(newsArticles);
        }
    }
}
