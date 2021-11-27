using ArticleChallenge.Application.ViewModels;
using ArticleChallenge.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Application.Mapper
{
    public class MapModelToViewModel: Profile
    {
        public MapModelToViewModel()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<LikeArticle, LikeArticleViewModel>();
        }
    }
}
