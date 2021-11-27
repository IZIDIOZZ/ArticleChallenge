using ArticleChallenge.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Domain.Interfaces
{
    public interface IArticleService
    {
        Task<ArticleViewModel> GetArticle(Guid articleId);
        Task<List<ArticleViewModel>> GetAllArticles();
        Task<ArticleViewModel> AddArticle(ArticleViewModel article);
        Task<ArticleViewModel> AddArticleLike(Guid articleId, Guid userLikedId);
        Task<ArticleViewModel> RemoveArticleLike(Guid articleId, Guid userLikedId);
        Task<bool> UserAlreadyLikedArticle(Guid articleId, Guid userLikedId);
    }
}
