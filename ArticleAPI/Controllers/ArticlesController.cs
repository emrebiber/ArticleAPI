using System;
using System.Collections.Generic;
using ArticleAPI.DAL.Models;
using ArticleAPI.DAL.Repositories.Article;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet("GetArticles")]
        public IActionResult GetArticles()
        {
            try
            {
                IEnumerable<Article> articles = _articleRepository.GetAllArticles();

                return Ok(new { result = true, articles = articles });
            }
            catch (Exception ex)
            {
                //TODO Do some kind of logging here... Log in db or text file??
                return Ok(new { result = false, message = ex.Message });
            }
        }

        [HttpGet("GetArticle/{id}")]
        public IActionResult GetArticle(int id)
        {
            try
            {
                var article = _articleRepository.GetArticleById(id);

                return Ok(new { result = true, article = article });
            }
            catch (Exception ex)
            {
                //TODO Do some kind of logging here... Log in db or text file??
                return Ok(new { result = false, message = ex.Message });
            }
        }

        [HttpPost("AddArticle")]
        public IActionResult AddArticle(Article article)
        {
            try
            {
                _articleRepository.AddArticle(article);

                return Ok(new { result = true, message = "Yeni makale oluşturuldu." });
            }
            catch (Exception ex)
            {
                //TODO Do some kind of logging here... Log in db or text file??
                return Ok(new { result = false, message = ex.Message });
            }
        }

        [HttpPut("UpdateArticle")]
        public IActionResult UpdateArticle(Article article)
        {
            try
            {
                var existingArticle = _articleRepository.GetArticleById(article.ArticleId);

                existingArticle.Name = article.Name;
                existingArticle.Content = article.Content;

                _articleRepository.UpdateArticle(existingArticle);

                return Ok(new { result = true, message = "Makale guncellendi." });

            }
            catch (Exception ex)
            {
                //TODO Do some kind of logging here... Log in db or text file??
                return Ok(new { result = false, message = ex.Message });
            }
        }

        [HttpDelete("DeleteArticle/{id}")]
        public IActionResult DeleteArticle(int id)
        {
            try
            {
                _articleRepository.DeleteArticle(id);

                return Ok(new { result = true, message = "Makale silindi." });
            }
            catch (Exception ex)
            {
                //TODO Do some kind of logging here... Log in db or text file??
                return Ok(new { result = false, message = ex.Message });
            }
        }


    }
}