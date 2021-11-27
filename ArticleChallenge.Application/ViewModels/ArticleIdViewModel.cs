using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleChallenge.Application.ViewModels
{
    public class ArticleIdViewModel
    {
        public Guid articleID { get; set; }
        public Guid userIdLiked { get; set; }
    }
}
