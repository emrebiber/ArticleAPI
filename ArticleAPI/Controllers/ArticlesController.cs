﻿using System;
using System.Collections.Generic;
using System.Linq;
using ArticleAPI.DAL.Models;
using ArticleAPI.DAL.Repositories.Article;
using ArticleAPI.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace ArticleAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private readonly Logger _logger;

        public ArticlesController(IArticleRepository articleRepository, IConfiguration configuration, IMemoryCache cache)
        {
            _articleRepository = articleRepository;
            _configuration = configuration;
            _cache = cache;
            _logger = new Logger($"{_configuration.GetSection("Logging").GetSection("LogPath").Value}",
                Convert.ToInt32(_configuration.GetSection("Logging").GetSection("LogLevel").Value));
        }

        [HttpGet("GetArticles")]
        public IActionResult GetArticles()
        {
            try
            {
                if (!_cache.TryGetValue("articles", out List<Article> articles))
                {
                    if (articles == null)
                    {
                        articles = _articleRepository.GetAllArticles().ToList();
                    }

                    _cache.Set("articles", articles);
                }

                return Ok(new { result = true, articles = articles });
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), LogType.Error);
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
                _logger.Log(ex.ToString(), LogType.Error);
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
                _logger.Log(ex.ToString(), LogType.Error);
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
                _logger.Log(ex.ToString(), LogType.Error);
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
                _logger.Log(ex.ToString(), LogType.Error);
                //TODO Do some kind of logging here... Log in db or text file??
                return Ok(new { result = false, message = ex.Message });
            }
        }


    }
}