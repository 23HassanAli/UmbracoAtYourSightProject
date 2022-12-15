using MyProject.Models.ViewModels;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace MyProject.Models
{
    public class SearchContentModel : ContentModel
    {
        public SearchContentModel(IPublishedContent? content) : base(content)
        {
        }
        public SearchViewModel SearchModel { get; set; }
        public IEnumerable<IPublishedContent> SearchResults { get; set; }
    }
}
