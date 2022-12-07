using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Net;
using System.Net.Mail;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Web.Website.ActionResults;

namespace MyProject.Controllers
{
    public class SubscriptionController : SurfaceController
    {
        public SubscriptionController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(SubscriptionViewModel svm)
        {

            var contentService = Services.ContentService;
            var parentId = Guid.Parse("58efab33-a235-4acd-ae21-8fae24fcc97e");
            if (ModelState.IsValid)
            {
               
                var contact = contentService.Create($"{svm.Email} - {DateTime.Now.ToString()}", parentId, "Subscriptions");
               
                contact.SetValue("subscriptionEmail", svm.Email);

                Services.ContentService.SaveAndPublish(contact);
                TempData["ContactSuccess"] = true;

                return RedirectToUmbracoPage(parentId);
            }
            return CurrentUmbracoPage();

        }
    }
}
