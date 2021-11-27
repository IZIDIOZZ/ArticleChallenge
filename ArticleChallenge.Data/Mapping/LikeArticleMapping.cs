using ArticleChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Data.Mapping
{
    class LikeArticleMapping : IEntityTypeConfiguration<LikeArticle>
    {
        public void Configure(EntityTypeBuilder<LikeArticle> builder)
        {
            builder.HasKey(x => x.LikeArticleId);
        }
    }
}
