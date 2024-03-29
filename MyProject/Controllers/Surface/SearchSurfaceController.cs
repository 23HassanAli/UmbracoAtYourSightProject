﻿using Microsoft.AspNetCore.Mvc;
using MyProject.Models.ViewModels;
using System.Collections.Specialized;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.ActionResults;
using Umbraco.Cms.Web.Website.Controllers;

namespace MyProject.Controllers.Surface
{
    public class SearchSurfaceController : SurfaceController
    {
        public SearchSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }

        public IActionResult SubmitForm(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            var queryString = new QueryString();
            if (!string.IsNullOrWhiteSpace(model.Query))
            {
                queryString = queryString.Add("query", model.Query);
            }
            if (!string.IsNullOrWhiteSpace(model.Category))
            {
                queryString = queryString.Add("category", model.Category);
            }
            if (!string.IsNullOrWhiteSpace(model.Page))
            {
               queryString = queryString.Add("page", model.Page);
            }

            return RedirectToCurrentUmbracoPage(queryString);
        }
       

    }
}
