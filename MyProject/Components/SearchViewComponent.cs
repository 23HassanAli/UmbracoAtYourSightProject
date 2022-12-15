using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Models.ViewModels;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyProject.Components
{
    [ViewComponent(Name = "Search")]
    public class SearchViewComponent : ViewComponent    
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var viewModel = new ComposedPageViewModel<Search, SearchViewModel>();
            viewModel.ViewModel = new SearchViewModel();
            return View(viewModel);
        }
    }
}
