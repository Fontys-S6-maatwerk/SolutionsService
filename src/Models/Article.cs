using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SolutionsService.Models.ResponseModels;
using SolutionsService.Logic;

namespace SolutionsService.Models
{
    public class Article : Solution
    {
        public Article()
        {
            this.SDGs = new HashSet<SDGSolution>();
            this.Likes = new HashSet<Like>();
        }

        public string Content { get; set; }

        public override ArticleResponse ConvertToResponseModel()
        {
            return ResponseModelBuilder.BuildArticleResponse(this);
        }
    }
}
