using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Domain.Entities
{
    public class ArticleLike
    {

        public Guid ArticleLikeId { get; private set; }
        public Guid ArticleId { get; private set; }
        public Article Article { get; private set; }

        public ArticleLike(Guid articleLikeId)
        {
            ArticleLikeId = Guid.NewGuid();
            ArticleId = articleLikeId;
        }
    }
}
