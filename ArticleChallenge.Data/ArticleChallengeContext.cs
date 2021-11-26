using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Data
{
    class ArticleChallengeContext: DbContext
    {

        public ArticleChallengeContext(DbContextOptions<ArticleChallengeContext> options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ArticleChallengeContext)));
        }

    }
}
