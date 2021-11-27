using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ArticleChallenge.Domain.Entities;

namespace ArticleChallenge.Data
{
    public class ArticleChallengeContext: DbContext
    {

        public DbSet<Article> Articles { get; set; }
        public DbSet<LikeArticle> LikeArticle { get; set; }

        public ArticleChallengeContext(DbContextOptions<ArticleChallengeContext> options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ArticleChallengeContext)));
            base.OnModelCreating(modelBuilder);
        }

    }
}
