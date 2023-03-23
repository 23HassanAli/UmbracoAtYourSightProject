using Google.Analytics.Data.V1Beta;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using Newtonsoft.Json;
using StackExchange.Profiling.Internal;
using System.Text;
using Umbraco.Cms.Web.Common.Controllers;

namespace MyProject.Controllers
{
    [Route("ga")]
    public class GoogleAnalyticsApiController : UmbracoApiController
    {
        private readonly Umbraco.Cms.Core.Hosting.IHostingEnvironment _environment;
        public GoogleAnalyticsApiController(Umbraco.Cms.Core.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public List<DimensionValue> DimensionValues { get; set; }
        public List<MetricValue> MetricValues { get; set; }
        [HttpGet]
        public async Task<string> GetAsync()

        {
            string credential_path = $"{_environment.ApplicationPhysicalPath}/GoogleCredentials/quickstart-1678906853030-58ee6cdf56d8.json";
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);
            var env = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            var propertyId = 358658902;
            //string value = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            BetaAnalyticsDataClient client = BetaAnalyticsDataClient.Create();
            //eventName

            List<Dimension> dimensions= new List<Dimension>();
            RunReportRequest request = new RunReportRequest
            {
                Property = "properties/" + propertyId,
                Dimensions = { new Dimension{ Name = "browser" }},                
                Metrics = { new Metric { Name = "active7DayUsers" } },
                DateRanges = { new DateRange { StartDate = "2022-03-01", EndDate = "2023-03-22" } },

            };

            var response = client.RunReport(request);


            //https://analyticsdata.googleapis.com/v1beta/properties/354119062:runreport

            var root = new RootObject();

     
                
                root = JsonConvert.DeserializeObject<RootObject>(response.ToJson(), new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in root.Rows)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
