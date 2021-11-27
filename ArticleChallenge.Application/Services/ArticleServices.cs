using ArticleChallenge.Application.ViewModels;
using ArticleChallenge.Domain.Entities;
using ArticleChallenge.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Application.Services
{
    public class ArticleServices : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleServices(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public async Task<ArticleViewModel> AddArticle(ArticleViewModel articleViewModel)
        {
            var article = new Article(articleViewModel.Author,
                                      articleViewModel.Title,
                                      articleViewModel.Content);

            await _articleRepository.AddArticle(article);
            return ArticleToArticleViewModel(article);
        }

        public async Task<ArticleViewModel> AddArticleLike(Guid articleId, Guid userLikedId)
        {
            var article = await _articleRepository.GetArticle(articleId);
           
            if (article is null) throw new Exception($"Nenhum Artigo com o Id {articleId} foi encontrado.");

            if (article.UserAlreadLiked(userLikedId)) throw new Exception($"Usuario informado ja deu like neste artigo");

            var LikeArticle = new LikeArticle(articleId, userLikedId);

            article.AddLikeArticle(LikeArticle);

            await _articleRepository.AddLikeArticle(LikeArticle);

            return ArticleToArticleViewModel(article);
        }

        public async Task<ArticleViewModel> RemoveArticleLike(Guid articleId, Guid userLikedId)
        {
            var article = await _articleRepository.GetArticle(articleId);

            if (article is null) throw new Exception($"Nenhum Artigo com o Id {articleId} foi encontrado.");

            var LikeArticle = article.GetUserLiked(userLikedId);
           
            if (LikeArticle is null) throw new Exception($"Usuário informado ainda não deu like neste artigo.");

            article.Likes.Remove(LikeArticle);

            await _articleRepository.RemoveLikeArticle(LikeArticle);

            return ArticleToArticleViewModel(article);
        }

        public async Task<List<ArticleViewModel>> GetAllArticles()
        {
           return ArticleToArticleViewModel(await _articleRepository.GetAllArticles());
        }

        public async Task<ArticleViewModel> GetArticle(Guid articleId)
        {
            var article = await _articleRepository.GetArticle(articleId);

            if(article is null) 
                throw new Exception("Nenhum artigo com o id informado foi encontrado.");

            return ArticleToArticleViewModel(article);
        }

        public ArticleViewModel ArticleToArticleViewModel(Article article)
        {
            var articleViewModel = _mapper.Map<ArticleViewModel>(article);
            articleViewModel.LikesCount = article.Likes.Count();
            return articleViewModel;
        }

        public List<ArticleViewModel> ArticleToArticleViewModel(List<Article> articleList)
        {
            var articleViewModelList = new List<ArticleViewModel>();
            articleList.ForEach(x =>
            {
                var articleViewModel = _mapper.Map<ArticleViewModel>(x);
                articleViewModel.LikesCount = x.Likes.Count();
                articleViewModelList.Add(articleViewModel);

            });
            return articleViewModelList;
        }

        public async Task<bool> UserAlreadyLikedArticle(Guid articleId,Guid userLikedId)
        {
            var likeArticle = await _articleRepository.GetLikeArticleByUser(articleId, userLikedId);

                return likeArticle != null;
        }
    }
}
