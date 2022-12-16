using Umbraco.Cms.Core.Models.PublishedContent;

namespace MyProject.Models.ViewModels
{
    public class ComposedPageViewModel<T, TViewModel>
        where T : PublishedContentModel
    {
        public T? Page { get; set; }

        public TViewModel? ViewModel { get; set; }

    }
}
