using J2N.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Repository;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Website.Controllers;

namespace MyProject.Controllers
{
    
    public class NewsArticlesController : UmbracoApiController
    {
        [HttpGet]
        public async Task<IEnumerable<NewsArticle>> GetAllArticles([FromQuery] string skip, [FromQuery]string take)
        {
            System.Collections.Generic.List<NewsArticle> list = new System.Collections.Generic.List<NewsArticle>();
            NewsApiRepository newsApiRepository = new NewsApiRepository(list);
            int.TryParse(skip, out var intSkip);
            int.TryParse(take, out var intTake);
            var newsArticles = await newsApiRepository.GetArticles(intSkip, intTake);
            return newsArticles;
        }
    }
}
