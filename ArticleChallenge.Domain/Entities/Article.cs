using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Domain.Entities
{
    public class Article
    {
      

        public Guid ArticleId { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishDate { get; private set; }
        public ICollection<LikeArticle> Likes { get; private set; }

        public Article(string author, string title, string content)
        {
            ArticleId = Guid.NewGuid();
            Author = author;
            Title = title;
            Content = content;
            PublishDate = DateTime.Now;
            Likes = new List<LikeArticle>();
        }

        public bool UserAlreadLiked(Guid userLikedId)
        {
            return Likes.FirstOrDefault(x => x.UserIdLiked == userLikedId) != null;
        }

        public LikeArticle GetUserLiked(Guid userLikedId)
        {
            return Likes.FirstOrDefault(x => x.UserIdLiked == userLikedId);
        }

        public void AddLikeArticle(LikeArticle LikeArticle)
        {
            Likes.Add(LikeArticle);
        }

        public void RemoveLikeArticle(LikeArticle LikeArticle)
        {
            Likes.Remove(LikeArticle);
        }
    }
}
