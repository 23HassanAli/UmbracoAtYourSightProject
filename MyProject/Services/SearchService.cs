using Examine;
using System;
using Examine.Search;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Infrastructure.Examine;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;

namespace MyProject.Services
{
    public class SearchService : ISearchService
    {
        private readonly UmbracoHelper _umbracoHelper;
        private readonly IUmbracoContextFactory _umbracoContextfactory;
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
             
            var pageOfReuslts = GetPageOfSearchResults(searchTerm, category, pageNumber, out totalItemCount, null, "content");
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
                var query = searcher.GroupedNot(new string[] {"umbracoNaviHide"}, new string[] {"1"});
                if (terms.Any())
                {
                    query.And(q => q.GroupedOr(new[] { "nodeName", "pageTitle", "bodyText", "authorName", "bodyText", "introText"  }, terms), BooleanOperation.Or);
                }
                if (docTypeAliases != null && docTypeAliases.Any())
                {
                    query.And(q => q.GroupedOr(new[] {"__NodeTypeAlias" }, docTypeAliases));
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
