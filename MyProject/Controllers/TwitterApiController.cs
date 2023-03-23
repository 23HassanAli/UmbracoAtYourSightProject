using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace MyProject.Controllers
{
    [Route("tw")]
    public class TwitterApiController : UmbracoApiController
    {
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter-data1.p.rapidapi.com/Search/?q=dogecoin&count=20"),
                Headers =
    {
        { "X-RapidAPI-Key", "470bf0a141msha0e8d64ae386145p1203b5jsne624adfd06db" },
        { "X-RapidAPI-Host", "twitter-data1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;    

            }

            return "no success";
        }
    }
}
