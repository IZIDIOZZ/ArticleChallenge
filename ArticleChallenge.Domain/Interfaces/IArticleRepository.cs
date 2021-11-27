using ArticleChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Domain.Interfaces
{
    public interface IArticleRepository
    {
       Task<Article> GetArticle(Guid articleId);
       Task<List<Article>> GetAllArticles();
       Task AddArticle(Article article);
       Task AddLikeArticle(LikeArticle articleLike);
       Task RemoveLikeArticle(LikeArticle articleLike);
       Task<LikeArticle> GetLikeArticleByUser(Guid articleId, Guid userIdLiked);
    }
}
