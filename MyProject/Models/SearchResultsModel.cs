using Umbraco.Cms.Core.Models.PublishedContent;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Models
{
    public class SearchResultsModel
    {
        public string SearchTerm { get; set; }
        public IEnumerable<IPublishedContent> Results { get; set; }
        public bool HasResults { get { return Results != null && Results.Count() > 0; } }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
        public PagingBoundsModel PagingBounds { get; set; }
    }
}
