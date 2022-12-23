using Lucene.Net.Index;
using MyProject.Components;
using MyProject.Data;
using MyProject.Models;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Xamarin.Essentials;

namespace MyProject.Repository
{
    public class NewsApiRepository
    {
        private HttpClient httpClient;
        private ArticlesData _articlesData;
        private List<NewsArticle> newNewsArticles;
        
        public NewsApiRepository(List<NewsArticle> newsArticles)
        {

            newNewsArticles = new List<NewsArticle>();
            if (newsArticles != null)
            {
                foreach(var item in newsArticles)
                {
                    newNewsArticles.Add(item);
                }
                
            }
                
        }
        public async Task<IEnumerable<NewsArticle>> GetArticles(int skip, int take)
        {

            List<NewsArticle> newsArticles = new List<NewsArticle>();
            
            try
            {               
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://newsapi.org/v2/");
                //httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.GetAsync("top-headlines?country=us&apiKey=baac9ab1bff648f0931df9f13f12a474");

                if (response.IsSuccessStatusCode)
                {
                    var root = new Root();
                    var jsonString = await response.Content.ReadAsStringAsync();                   
                    root = JsonConvert.DeserializeObject<Root>(jsonString, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    });
                    //newsArticles = root.Articles;
               
                                
                    foreach (var item in root.Articles.Skip(skip).Take(take))
                    {
                        newsArticles.Add(item);
                    }
                    return newsArticles;
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return newsArticles;
        }
    }
}
