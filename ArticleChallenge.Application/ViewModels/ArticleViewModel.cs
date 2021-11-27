using ArticleChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Application.ViewModels
{
    public class ArticleViewModel
    {
        public Guid ArticleId { get;  set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get;  set; }
        public List<LikeArticleViewModel> Likes { get; set; }
        public int LikesCount { get; set; }
    }
}
