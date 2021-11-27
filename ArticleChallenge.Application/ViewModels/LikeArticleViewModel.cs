using ArticleChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Application.ViewModels
{
    public class LikeArticleViewModel
    {
        public Guid LikeArticleId { get; set; }
        public Guid ArticleId { get; set; }
        public ArticleViewModel Article { get; set; }
    }
}
