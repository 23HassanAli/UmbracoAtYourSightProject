using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MyProject.Models;
using MyProject.Models.ViewModels;
using MyProject.Services;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace MyProject.Controllers
{
    public class SearchController : RenderController
    {
        private readonly ISearchService _searchService;
        public SearchController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, ISearchService searchService) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _searchService = searchService;
        }
        
        [HttpGet]
        public IActionResult Index(ContentModel model, string query, string page, string category)
        {
            var searchPageModel = new SearchContentModel(model.Content);
            var searchViewModel = new SearchViewModel()
            {
                Query = query,
                Category = category,
                Page = page
            };
             
            int pageNumber;
            if (!int.TryParse(page, out pageNumber))
            {
                pageNumber = 1; 
            }
            if (!string.IsNullOrWhiteSpace(query))
            {
                var searchResults = _searchService.GetPageOfContentSearchResults(query, category, 
                    pageNumber, out var totalItemCount, null);
                searchPageModel.SearchResults = searchResults;
                
            }
            searchPageModel.SearchModel = searchViewModel;

            return CurrentTemplate(searchPageModel);
        }
    }
}
