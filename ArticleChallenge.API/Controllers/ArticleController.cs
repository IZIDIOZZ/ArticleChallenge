using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArticleChallenge.Data;
using ArticleChallenge.Domain.Entities;
using ArticleChallenge.Application.ViewModels;
using ArticleChallenge.Domain.Interfaces;

namespace ArticleChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly ArticleChallengeContext _context;

        private readonly IArticleService _articleService;

        public ArticleController(ArticleChallengeContext context, IArticleService articleService)
        {
            _context = context;
            _articleService = articleService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllArticles()
        {
            try
            {
                var articleList = await _articleService.GetAllArticles();

                return Ok(articleList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{articleId}")]
        public async Task<IActionResult> GetArticle(Guid articleId)
        {
            try
            {
                if (articleId == Guid.Empty) return BadRequest("Insira um Id para realizar a busca.");
                
                var article = await _articleService.GetArticle(articleId);

                return Ok(article);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddArticle([FromBody] ArticleViewModel articleViewModel)
        {
            try
            {
                var article = await _articleService.AddArticle(articleViewModel);
                return Ok(article);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("like")]
        public async Task<IActionResult> AddArticleLike([FromBody] ArticleIdViewModel ArticleIdViewModel)
        {
            try
            {
                var articleId = ArticleIdViewModel.articleID;

                if (articleId == Guid.Empty) return BadRequest("O Id de um Artigo é necessário para adicionar o Like");

                var article = await _articleService.AddArticleLike(articleId, ArticleIdViewModel.userIdLiked);

                return Ok(article);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("like/remove/{articleId}/{userIdLiked}")]
        public async Task<IActionResult> RemoveArticleLike(Guid articleId, Guid userIdLiked)
        {
            try
            {
                if (articleId == Guid.Empty) return BadRequest("O Id de um Artigo é necessário para adicionar o Like");
                if (userIdLiked == Guid.Empty) return BadRequest("Id de usuário não foi informado.");

                var article = await _articleService.RemoveArticleLike(articleId, userIdLiked);

                return Ok(article);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("like/alreadyLiked/{articleId}/{userIdLiked}")]
        public async Task<IActionResult> UserAlreadyLiked(Guid articleId, Guid userIdLiked)
        {
            try
            {
                if (articleId == Guid.Empty) return BadRequest("O Id de um Artigo é necessário.");
                if (userIdLiked == Guid.Empty) return BadRequest("Id de usuário não foi informado.");

                var userAlreadyLiked = await _articleService.UserAlreadyLikedArticle(articleId, userIdLiked);

                return Ok(userAlreadyLiked);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
