using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Domain.Entities
{
    public class LikeArticle
    {
        public Guid LikeArticleId { get; private set; }
        public Guid ArticleId { get; private set; }
        public Article Article { get; private set; }
        public Guid UserIdLiked { get; private set; }

        public LikeArticle(Guid articleId, Guid userIdLiked)
        {
            ArticleId = articleId;
            LikeArticleId = Guid.NewGuid();
            UserIdLiked = userIdLiked;
        }
    }
}
