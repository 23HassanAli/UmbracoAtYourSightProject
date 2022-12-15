using Examine;
using System.ComponentModel;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace MyProject.Services
{
    public interface ISearchService
    {
        IEnumerable<IPublishedContent> GetPageOfContentSearchResults(string searchTerm, string category,
           int pageNumber, out long totalItemCount,
           string[] docTypeAliases,
           int pageSize = 10);
        IEnumerable<ISearchResult> GetPageOfSearchResults(string searchTerm, string category, 
            int pageNumber, 
            out long totalItemCount, string[] docTypeAliases, 
            string searchType,
            int pageSize = 10);
       

    }
}
