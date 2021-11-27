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
    class ArticleMapping: IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ArticleId);

            builder.HasMany(x => x.Likes)
                   .WithOne(x => x.Article)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
