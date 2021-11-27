using ArticleChallenge.Domain.Entities;
using ArticleChallenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Data.Repository
{
    public class ArticleRepository: IArticleRepository
    {
        ArticleChallengeContext _articleContext;

        public ArticleRepository(ArticleChallengeContext articleContext)
        {
            _articleContext = articleContext;
        }

        public async Task<Article> GetArticle(Guid articleId)
        {
           return await _articleContext.Articles
                .Include(x => x.Likes)
                .FirstOrDefaultAsync(x => x.ArticleId == articleId);
        }

        public async Task<List<Article>> GetAllArticles()
        {
            return await _articleContext.Articles
                 .Include(x => x.Likes)
                 .ToListAsync();
        }

        public async Task AddArticle(Article article)
        {
            await _articleContext.Articles.AddAsync(article);
            await _articleContext.SaveChangesAsync();
        }

        public async Task AddLikeArticle(LikeArticle articleLike)
        {
            await _articleContext.ArticleLikes.AddAsync(articleLike);
            await _articleContext.SaveChangesAsync();
        }
    }
}
