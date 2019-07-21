using System.Collections.Generic;

namespace ArticleAPI.DAL.Repositories.Article
{
    public interface IArticleRepository
    {
        IEnumerable<Models.Article> GetAllArticles();
        Models.Article GetArticleById(int articleId);
        void AddArticle(Models.Article article);
        void UpdateArticle(Models.Article article);
        void DeleteArticle(int articleId);
    }
}
