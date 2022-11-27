using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Website.Controllers;

namespace MyProject.Controllers
{
    [Route("weather")]
    public class WeatherController : UmbracoApiController
    {
       
        [HttpGet]
        public int GetTemp()
        {
            return 20;
        }

    }
}
