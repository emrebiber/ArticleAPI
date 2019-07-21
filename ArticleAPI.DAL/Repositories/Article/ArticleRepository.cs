using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace ArticleAPI.DAL.Repositories.Article
{
    public class ArticleRepository : IArticleRepository
    {
        public IEnumerable<Models.Article> GetAllArticles()
        {
            using (var connection = new MySqlConnection(DbConfig.GetConnectionString()))
            {
                var sql = "select * from Article";

                return connection.Query<Models.Article>(sql);
            }
        }

        public Models.Article GetArticleById(int articleId)
        {
            using (var connection = new MySqlConnection(DbConfig.GetConnectionString()))
            {
                string sql = "select * from Article where ArticleId = @articleId";

                return connection.QuerySingleOrDefault<Models.Article>(sql, new { ArticleId = articleId });
            }
        }

        public void AddArticle(Models.Article article)
        {
            using (var connection = new MySqlConnection(DbConfig.GetConnectionString()))
            {
                connection.Query("insert into Article (Name, Content, CreatedDate) values (@Name, @Content, @CreatedDate)",
                    new
                    {
                        Name = article.Name,
                        Content = article.Content,
                        CreatedDate = DateTime.Now,
                    });
            }
        }

        public void UpdateArticle(Models.Article article)
        {
            using (var connection = new MySqlConnection(DbConfig.GetConnectionString()))
            {
                connection.Query("Update Article set Name = @Name, Content = @Content where ArticleId = @articleId",
                    new
                    {
                        ArticleId = article.ArticleId,
                        Name = article.Name,
                        Content = article.Content
                    });
            }
        }

        public void DeleteArticle(int articleId)
        {
            using (var connection = new MySqlConnection(DbConfig.GetConnectionString()))
            {
                connection.Query("Delete from Article where ArticleId = @articleId", new { articleId = articleId });
            }
        }
    }
}
