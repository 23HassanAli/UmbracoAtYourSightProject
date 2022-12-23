using Microsoft.AspNetCore.Authentication;
using MyProject.Models;

namespace MyProject.Data
{
    public class ArticlesData
    {
        public Root? NewsArticles { get; set; }
        public List<NewsArticle>? ArticlesList = new List<NewsArticle>();

        public void AddArticles(NewsArticle newsArticle)
        {
             
            ArticlesList.Add(newsArticle);
            
        }
    }
}
