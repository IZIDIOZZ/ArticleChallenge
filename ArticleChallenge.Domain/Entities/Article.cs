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
        public List<ArticleLike> Likes { get; private set; }

        public Article(string author, string title, string content)
        {
            ArticleId = Guid.NewGuid();
            Author = author;
            Title = title;
            Content = content;
            Likes = new List<ArticleLike>();
        }

        public void AddLike(ArticleLike articleLike)
        {
            Likes.Add(articleLike);
        }
    }
}
