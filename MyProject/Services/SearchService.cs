using Examine;
using System;
using Examine.Search;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Infrastructure.Examine;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using MyProject.Extensions;

namespace MyProject.Services
{
    public class SearchService : ISearchService
    {
        private readonly UmbracoHelper _umbracoHelper;
        //private readonly IUmbracoContextFactory _umbracoContextfactory;
        private readonly IExamineManager _examineManager;
        public SearchService(IExamineManager examineManager, UmbracoHelper umbracoHelper)
        {
            _examineManager= examineManager;
            _umbracoHelper = umbracoHelper;  
        }
        public IEnumerable<IPublishedContent> GetPageOfContentSearchResults(string searchTerm, 
            string category, int pageNumber, out long totalItemCount, 
            string[] docTypeAliases,
            int pageSize = 10)
        {
             
            var pageOfReuslts = GetPageOfSearchResults(searchTerm, category, pageNumber, out totalItemCount, docTypeAliases, "content");
            var items = new List<IPublishedContent>();
            if (pageOfReuslts != null && pageOfReuslts.Any())
            {
                foreach (var item in pageOfReuslts)
                {
                    var page = _umbracoHelper.Content(item.Id);
                //.ContentAtRoot()
                //.FirstOrDefault();
                    //_umbracoContextfactory.EnsureUmbracoContext().UmbracoContext.Content.GetById(item.Id);
                    if (page != null)
                    {
                        items.Add(page);
                    }
                }
            }
            return items;

        }

        public IEnumerable<ISearchResult> GetPageOfSearchResults(string searchTerm, string category, 
            int pageNumber, out long totalItemCount, string[] docTypeAliases,
            string searchType, int pageSize = 10)
        {
            int skip = pageNumber > 1 ? (pageNumber - 1) * pageSize : 0;
                     
            if (_examineManager.TryGetIndex(Umbraco.Cms.Core.Constants.UmbracoIndexes.ExternalIndexName, out var index))
            {
                string[]? terms = !string.IsNullOrEmpty(searchTerm) && searchTerm.Contains(" ")
                    ? searchTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    : !string.IsNullOrWhiteSpace(searchTerm) ? new string[] { searchTerm } : null;
                var searcher = index.Searcher.CreateQuery(searchType);
                    
                    //.And().Field("category", category);
                var query = searcher.GroupedNot(new string[] {"umbracoNaviHide"}, new string[] {"1"});
                if (terms.Any())
                {
                    query.And(q => q
                    //.GroupedOr(new[] { "" }, terms.Boost(10))
                    //.Or()
                    .GroupedOr(new[] { "blogHome" }, terms.Boost(12))
                    .Or()
                    .GroupedOr(new[] { "blogItem" }, terms.Boost(7))
                    .Or()
                    .GroupedOr(new[] { "pageTitle" }, terms.Boost(6))
                    .Or()
                    .GroupedOr(new[] { "bodyText" }, terms.Boost(5))
                    .Or()
                    .GroupedOr(new[] { "authorName" }, terms.Boost(4))
                    .Or()
                    .GroupedOr(new[] { "blogHome", "blogItem", "pageTitle", "bodyText", "authorName", "bodyText", "introText", "category"  }, terms.Fuzzy()), BooleanOperation.Or);
                }
                if (docTypeAliases != null && docTypeAliases.Any())
                {
                    query.And(q => q.GroupedOr(new[] { "__NodeTypeAlias" }, docTypeAliases));
                }
                //if (!string.IsNullOrWhiteSpace(category))
                //{
                //    query.And().Field("searchbableCatergories", category);
                //}
                var allResults = query.Execute();
                totalItemCount  = allResults.TotalItemCount;
                var pageOfResults = allResults.Skip(skip).Take(pageSize);

                return pageOfResults;

            }

            totalItemCount = 0;
            return Enumerable.Empty<ISearchResult>();  
        }
    }
}
