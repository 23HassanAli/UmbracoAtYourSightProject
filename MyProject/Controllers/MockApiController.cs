using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Repository;
using Umbraco.Cms.Web.Common.Controllers;

namespace MyProject.Controllers
{
    public class MockApiController : UmbracoApiController
    {
        [HttpGet]
        public async Task<IEnumerable<NewsArticle>> GetData()
        {
            System.Collections.Generic.List<NewsArticle> list = new System.Collections.Generic.List<NewsArticle>();
        
            MockApiRepository apiRepository = new MockApiRepository();
            apiRepository.GetData();
            return list;

        }
    }
}
